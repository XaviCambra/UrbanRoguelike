using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    Module_AttackMele m_AttackMele;
    Module_Dash m_Dash;
    GameObject m_Player;
    NavMeshAgent m_NavMeshAgent;
    [SerializeField] private bool m_HasToDash;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_Dash = GetComponent<Module_Dash>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        m_Blackboard.m_CanAttack = true;
    }

    protected override void SetStateIdle()
    {
        base.SetStateIdle();
        m_NavMeshAgent.destination = transform.position;
    }

    public override void StateIdle()
    {
        base.StateIdle();
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateMovement();
    }

    protected override void SetStateMovement()
    {
        base.SetStateMovement();

        float l_Distance = Vector3.Distance(transform.position, m_Player.transform.position);

        if (l_Distance > m_Blackboard.m_DashChargedDistance)
            m_HasToDash = true;
    }

    public override void StateMovement()
    {
        float l_Distance = Vector3.Distance(m_Player.transform.position, transform.position);

        if (l_Distance < m_Blackboard.m_AttackDistance)
        {
            SetStateAttack();
            return;
        }

        if (l_Distance > m_Blackboard.m_DetectionRadius)
        {
            Debug.Log("Setted Idle");
            SetStateIdle();
            return;
        }

        if (m_HasToDash && l_Distance < m_Blackboard.m_DashDistance + m_Blackboard.m_AttackDistance  * 0.95f)
        {
            m_Dash.DashDisplacement((m_Player.transform.position - transform.position).normalized, m_Blackboard.m_DashDistance, m_Blackboard.m_DashSpeed);
            m_HasToDash = false;
            Attack();
            return;
        }

        Vector3 l_ClosestPointOnPlayer = m_Player.transform.position - (m_Player.transform.position - transform.position).normalized * (m_Blackboard.m_AttackDistance * 0.95f);
        m_NavMeshAgent.SetDestination(l_ClosestPointOnPlayer);
    }

    public override void StateAttack()
    {
        m_NavMeshAgent.destination = transform.position;
        transform.LookAt(m_Player.transform.position);
        Attack();
    }

    private void Attack()
    {
        m_AttackMele.HitOnDirection(m_Blackboard.m_BulletDamage);
        SetStateWait(m_Blackboard.m_BulletCooldown);
    }
}
