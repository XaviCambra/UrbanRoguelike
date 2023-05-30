using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    GameObject m_PlayerHitpoint;
    LineRenderer m_LineRenderer;
    
    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private float m_GrenadeForce;

    private enum AttackType
    {
        Bullet,
        Grenade,
        Misile
    }
    [SerializeField] private AttackType m_AttackType;
    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");
        m_LineRenderer = GetComponent<LineRenderer>();

        m_Blackboard.m_IsActive = false;
    }

    protected override void Update()
    {
        base.Update();
        m_LineRenderer.SetPosition(0, m_Blackboard.m_AttackPoint.position);
        m_LineRenderer.SetPosition(1, m_PlayerHitpoint.transform.position);
    }

    protected override void SetStateIdle()
    {
        m_State = EnemyStates.Attack;
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
                //StartCoroutine(GrenadeCooldown());
                break;
            case AttackType.Misile:
                break;
            default:
                break;
        }
        m_Blackboard.m_CanAttack = false;
        SetStateWait(m_Blackboard.m_AttackCooldown + 3);
    }
}
