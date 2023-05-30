using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FinalBossEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    GameObject m_PlayerHitpoint;
    GameObject m_Player;
    LineRenderer m_LineRenderer;

    Module_Health m_Health;

    public BossPhase[] m_Phases;

    [SerializeField] private GameObject m_MeleEnemy;
    [SerializeField] private GameObject[] m_SpawnPoints;

    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private float m_GrenadeForce;

    [SerializeField] private bool m_MisileUnlocked = false;

    private enum AttackType
    {
        Bullet = 0,
        Grenade = 1,
        Misile = 2
    }
    [SerializeField] private AttackType m_AttackType;
    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_LineRenderer = GetComponent<LineRenderer>();
        m_Health = GetComponent<Module_Health>();

        m_Blackboard.m_IsActive = false;
    }

    protected override void Update()
    {
        base.Update();
        transform.LookAt(m_Player.transform.position);

        m_LineRenderer.enabled = m_Blackboard.m_IsActive;
        m_LineRenderer.SetPosition(0, m_Blackboard.m_AttackPoint.position);
        m_LineRenderer.SetPosition(1, m_PlayerHitpoint.transform.position);
    }

    protected override void SetStateIdle()
    {
        base.SetStateIdle();
        foreach (BossPhase l_Phase in m_Phases)
        {
            if (m_Health.GetHealthPercent() > l_Phase.m_LifePercent)
                return;

            if (l_Phase.m_IsCompleted)
                return;

            for (int i = 0; i < l_Phase.m_InvokedEnemiesNumber; i++)
            {
                int rnd = UnityEngine.Random.Range(0, m_SpawnPoints.Length - 1);
                Vector3 RandomPos = m_SpawnPoints[rnd].transform.position;
                Instantiate(m_MeleEnemy, RandomPos, Quaternion.identity);
                if (l_Phase.m_LifePercent == 50)
                    m_MisileUnlocked = true;
            }
            l_Phase.m_IsCompleted = true;
        }
        
    }

    public override void StateIdle()
    {
        base.StateIdle();
        SetStateAttack();
    }

    protected override void SetStateAttack()
    {
        base.SetStateAttack();

        if (m_Blackboard.m_GrenadeLoaded)
        {
            m_AttackType = AttackType.Grenade;
            StartCoroutine(AttackDuration(m_Blackboard.m_GrenadeAttackDuration));
            StartCoroutine(GrenadeCooldown());
            return;
        }
        if (m_Blackboard.m_MisileLoaded && m_MisileUnlocked)
        {
            m_AttackType = AttackType.Misile;
            StartCoroutine(AttackDuration(m_Blackboard.m_GrenadeAttackDuration));
            StartCoroutine(MisileCooldown());
            return;
        }
        m_AttackType = AttackType.Bullet;
        StartCoroutine(AttackDuration(m_Blackboard.m_BulletAttackDuration));
    }

    public override void StateAttack()
    {
        base.StateAttack();

        switch (m_AttackType)
        {
            case AttackType.Bullet:
                if (m_Blackboard.m_BulletLoaded)
                {
                    m_Blackboard.m_RotationAttackPoint.localRotation = Quaternion.Euler(0, UnityEngine.Random.Range(-m_Blackboard.m_BulletAngle/2, m_Blackboard.m_BulletAngle/2), 0);
                    m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_RotationAttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_BulletDamage, "Enemy");
                    m_Blackboard.m_BulletLoaded = false;
                    StartCoroutine(BulletCooldown());
                }
                break;
            case AttackType.Grenade:
                GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
                Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
                l_rb.AddForce(m_Blackboard.m_AttackPoint.transform.forward * m_GrenadeForce, ForceMode.VelocityChange);
                l_rb.useGravity = true;
                l_grenade.SetActive(true);
                m_Blackboard.m_GrenadeLoaded = false;
                break;
            case AttackType.Misile:

                break;
            default:
                break;
        }
    }

    private IEnumerator BulletCooldown()
    {
        yield return new WaitForSeconds(m_Blackboard.m_BulletCooldown);
        m_Blackboard.m_BulletLoaded = true;
    }

    private IEnumerator AttackDuration(float l_Duration)
    {
        Debug.Log(l_Duration);
        yield return new WaitForSeconds(l_Duration);
        Debug.Log("Setted Wait Time");
        SetStateWait(m_Blackboard.m_BulletCooldown);
    }

    private IEnumerator GrenadeCooldown()
    {
        m_Blackboard.m_GrenadeLoaded = false;
        yield return new WaitForSeconds(m_Blackboard.m_GrenadeCooldown);
        m_Blackboard.m_GrenadeLoaded = true;
    }

    private IEnumerator MisileCooldown()
    {
        m_Blackboard.m_MisileLoaded = false;
        yield return new WaitForSeconds(m_Blackboard.m_GrenadeCooldown);
        m_Blackboard.m_MisileLoaded = true;
    }

}


[Serializable]
public class BossPhase
{
    public int m_LifePercent;
    public int m_InvokedEnemiesNumber;
    public bool m_IsCompleted = false;
}
