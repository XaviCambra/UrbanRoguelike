using System.Collections;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    Module_Crouch m_Crouch;
    GameObject m_PlayerHitpoint;
    GameObject m_Player;

    LineRenderer m_LineRenderer;
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
        m_LineRenderer = GetComponent<LineRenderer>();

        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_LineRenderer.enabled = false;

        StartCoroutine(CrouchIn());
    }

    protected override void Update()
    {
        base.Update();
        transform.LookAt(m_Player.transform.position);
        m_Blackboard.m_AttackPoint.transform.LookAt(m_PlayerHitpoint.transform);
        m_LineRenderer.SetPosition(0, m_Blackboard.m_AttackPoint.position);
        m_LineRenderer.SetPosition(1, m_PlayerHitpoint.transform.position);
    }

    public override void StateIdle()
    {
        base.StateIdle();
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateAttack();
    }

    protected override void SetStateAttack()
    {
        Debug.Log("Is Attack");
        if (m_Blackboard.m_GrenadeLoaded)
            m_AttackType = AttackType.Grenade;
        else
            m_AttackType = AttackType.Bullet;
        StartCoroutine(CrouchOut());
        base.SetStateAttack();
    }

    public override void StateAttack()
    {
        base.StateAttack();

        if (!m_Blackboard.m_CanAttack)
            return;

        Debug.Log("Dispara");
        switch (m_AttackType)
        {
            case AttackType.Bullet:
                m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage, "Enemy");
                break;
            case AttackType.Grenade:
                GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
                Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
                l_rb.AddForce(m_Blackboard.m_AttackPoint.transform.forward * m_GrenadeForce, ForceMode.VelocityChange);
                l_rb.useGravity = true;
                l_grenade.SetActive(true);
                m_Blackboard.m_GrenadeLoaded = false;
                StartCoroutine(GrenadeCooldown());
                break;
            default:
                break;
        }
        m_Blackboard.m_CanAttack = false;
        StartCoroutine(CrouchIn());
        SetStateWait(m_Blackboard.m_AttackCooldown + 3);
    }

    private IEnumerator CrouchOut()
    {
        Debug.Log("Is Idle");
        m_Crouch.Crouching(true, m_Blackboard.m_CrouchOutTime); //0
        m_LineRenderer.enabled = true;
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Se levanta");
        m_Blackboard.m_CanAttack = true;
    }

    private IEnumerator CrouchIn()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Se agacha");
        m_Crouch.Crouching(false, m_Blackboard.m_CrouchInTime); //2
        m_LineRenderer.enabled = false;
    }

    private IEnumerator GrenadeCooldown()
    {
        yield return new WaitForSeconds(m_Blackboard.m_GrenadeCooldown);
        m_Blackboard.m_GrenadeLoaded = true;
    }
}
