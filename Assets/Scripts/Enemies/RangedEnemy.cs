using System.Collections;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    Module_Crouch m_Crouch;
    GameObject m_PlayerHitpoint;
    GameObject m_Player;

    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private float m_GrenadeForce;

    private enum AttackType
    {
        Bullet,
        Grenade
    }

    [SerializeField] private AttackType m_AttackType;

    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_Crouch = GetComponent<Module_Crouch>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        m_Blackboard.m_CanAttack = true;
    }

    protected override void Update()
    {
        base.Update();

        m_Blackboard.m_AttackPoint.transform.LookAt(m_PlayerHitpoint.transform);
    }

    public override void StateIdle()
    {
        base.StateIdle();
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateAttack();
    }

    protected override void SetStateAttack()
    {
        StartCoroutine(CrouchOut());        
        base.SetStateAttack();
    }

    public override void StateAttack()
    {
        base.StateAttack();

        if (!m_Blackboard.m_CanAttack)
            return;

        Debug.Log(m_AttackType);
        switch (m_AttackType)
        {
            case AttackType.Bullet:
                m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage, "Enemy");
                break;
            case AttackType.Grenade:
                GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
                Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
                l_rb.AddForce(m_Blackboard.m_AttackPoint.transform.forward * m_GrenadeForce, ForceMode.VelocityChange);
                l_grenade.SetActive(true);
                break;
            default:
                break;
        }
        m_Blackboard.m_CanAttack = false;
        StartCoroutine(CrouchIn());
    }

    private IEnumerator CrouchOut()
    {
        yield return new WaitForSeconds(1.0f);
        m_Crouch.Crouching(true, 1);
        Debug.Log("Crouch Out");
        m_Blackboard.m_CanAttack = true;
    }

    private IEnumerator CrouchIn()
    {
        yield return new WaitForSeconds(3.0f);
        m_Crouch.Crouching(false, 0);
        Debug.Log("Crouch In");
        SetStateWait(m_Blackboard.m_AttackCooldown);
    }

    private IEnumerator GrenadeCooldown()
    {
        yield return null;
    }
}
