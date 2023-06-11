using System.Collections;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    Module_Crouch m_Crouch;
    GameObject m_PlayerHitpoint;
    GameObject m_Player;

    LineRenderer m_LineRenderer;
    [SerializeField] private bool m_HasGrenade;
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
        m_LineRenderer = GetComponent<LineRenderer>();

        m_LineRenderer.enabled = false;
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
        if (m_HasGrenade)
        {
            if (m_Blackboard.m_GrenadeLoaded)
                m_AttackType = AttackType.Grenade;
            else
                m_AttackType = AttackType.Bullet;
        }
        else
            m_AttackType = AttackType.Bullet;

        base.SetStateAttack();
    }

    public override void StateAttack()
    {
        base.StateAttack();

        if (!m_Blackboard.m_CanAttack)
            return;

        switch (m_AttackType)
        {
            case AttackType.Bullet:
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_RangedShoot, transform.position);

                m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_BulletDamage, "Enemy");
                break;
            case AttackType.Grenade:
                GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_GrenadeThrow, transform.position);

                Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
                Vector3 l_GrenadeUpScale = Vector3.up * m_Blackboard.m_GrenadeAngle;
                l_rb.AddForce(m_Blackboard.m_AttackPoint.transform.forward * m_Blackboard.m_GrenadeForce + l_GrenadeUpScale, ForceMode.VelocityChange);
                l_rb.useGravity = true;
                l_grenade.SetActive(true);
                m_Blackboard.m_GrenadeLoaded = false;
                StartCoroutine(GrenadeCooldown());
                break;
            default:
                break;
        }
        m_Blackboard.m_CanAttack = false;
        SetStateWait(m_Blackboard.m_AttackRecovery);
    }

    private IEnumerator GrenadeCooldown()
    {
        yield return new WaitForSeconds(m_Blackboard.m_GrenadeCooldown);
        m_Blackboard.m_GrenadeLoaded = true;
    }
}
