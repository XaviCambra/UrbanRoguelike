using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    GameObject m_PlayerHitpoint;
    GameObject m_Player;

    LineRenderer m_LineRenderer;
    [SerializeField] private bool m_HasGrenade;
    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private float m_GrenadeForce;

    float m_Timer = 0;

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
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_LineRenderer = GetComponent<LineRenderer>();

        m_LineRenderer.enabled = false;
    }

    protected override void Update()
    {
        base.Update();
        Vector3 l_PlayerDirection = m_Player.transform.position;
        l_PlayerDirection.y = transform.position.y;
        transform.LookAt(l_PlayerDirection);
        m_Blackboard.m_TurretRotation.transform.LookAt(m_PlayerHitpoint.transform);

        m_LineRenderer.SetPosition(0, m_Blackboard.m_AttackPoint.position);
        RaycastHit l_RayCast;
        if (Physics.Raycast(m_Blackboard.m_AttackPoint.position, m_PlayerHitpoint.transform.position - m_Blackboard.m_AttackPoint.position, out l_RayCast, Mathf.Infinity))
        {
            m_LineRenderer.SetPosition(1, l_RayCast.point);
        }
        else
        {
            m_LineRenderer.SetPosition(1, m_PlayerHitpoint.transform.position);
        }
        
    }

    public override void StateIdle()
    {
        base.StateIdle();
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateAttack();
    }

    protected override void SetStateAttack()
    {
        m_LineRenderer.enabled = true;
        m_Timer = 0;
        if (m_HasGrenade && m_Blackboard.m_GrenadeLoaded)
            m_AttackType = AttackType.Grenade;
        else
            m_AttackType = AttackType.Bullet;

        base.SetStateAttack();
    }

    public override void StateAttack()
    {
        base.StateAttack();

        if (!AttackLoaded())
            return;

        switch (m_AttackType)
        {
            case AttackType.Bullet:
                if (FindObjectOfType<AudioManager>() != null)
                    AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_RangedShoot, transform.position);

                m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_BulletDamage, "Enemy");
                break;
            case AttackType.Grenade:
                GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
                if (FindObjectOfType<AudioManager>() != null)
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
        m_LineRenderer.enabled = false;
        SetStateWait(m_Blackboard.m_AttackRecovery);
    }

    private bool AttackLoaded()
    {
        Debug.Log(m_Timer + " >= " + m_Blackboard.m_BulletAttackDuration + "? " + (m_Timer >= m_Blackboard.m_BulletAttackDuration));
        m_Timer += Time.deltaTime;
        return m_Timer >= m_Blackboard.m_BulletAttackDuration;
    }

    private IEnumerator GrenadeCooldown()
    {
        yield return new WaitForSeconds(m_Blackboard.m_GrenadeCooldown);
        m_Blackboard.m_GrenadeLoaded = true;
    }
}
