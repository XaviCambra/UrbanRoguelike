using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    Module_AttackMele m_AttackMele;
    Module_Dash m_Dash;
    [SerializeField] GameObject m_Player;
    NavMeshAgent m_NavMeshAgent;


    private bool m_CanAttack;
    private bool m_AttackOnCooldown;
    private bool m_HasToDash;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_Dash = GetComponent<Module_Dash>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        m_Blackboard.m_CanAttack = true;
        m_AttackOnCooldown = false;
    }
    public override void StateIdle()
    {
        base.StateIdle();
        Debug.Log(m_Blackboard.m_DetectionRadius + " - " + Vector3.Distance(m_Player.transform.position, transform.position));
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateMovement();
    }

    protected override void SetStateMovement()
    {
        float l_Distance = Vector3.Distance(transform.position, m_Player.transform.position);

        if (l_Distance > m_Blackboard.m_DashChargedDistance)
            m_HasToDash = true;

        if (l_Distance < m_Blackboard.m_FollowDistance)
            m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;
        else
            m_NavMeshAgent.speed = m_Blackboard.m_WalkSpeed;

        base.SetStateMovement();
    }

    public override void StateMovement()
    {
        Debug.Log(m_Blackboard.m_DetectionRadius + " - " + Vector3.Distance(m_Player.transform.position, transform.position));
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_AttackDistance)
        {
            SetStateAttack();
            return;
        }
        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_DetectionRadius)
        {
            SetStateIdle();
            return;
        }

        //Debug.Log(m_HasToDash);
        //Debug.Log(Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DashDistance + m_Blackboard.m_AttackDistance * 0.95f);
        if (m_HasToDash && Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DashDistance + m_Blackboard.m_AttackDistance  * 0.95f)
        {
            m_HasToDash = m_Dash.DashDisplacement((m_Player.transform.position - transform.position).normalized, m_Blackboard.m_DashDistance, m_Blackboard.m_DashSpeed);
            Attack();
            return;
        }

        Vector3 l_ClosestPointOnPlayer = m_Player.transform.position - (m_Player.transform.position - transform.position).normalized * (m_Blackboard.m_AttackDistance * 0.95f);
        m_NavMeshAgent.SetDestination(l_ClosestPointOnPlayer);
    }

    public override void StateAttack()
    {
        Debug.Log(Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_DetectionRadius);
        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_DetectionRadius)
            SetStateIdle();
        Debug.Log(Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance);
        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance)
            SetStateMovement();

        transform.LookAt(m_Player.transform.position);

        Attack();
    }

    private void Attack()
    {
        m_AttackMele.HitOnDirection(m_Blackboard.m_Damage);
        SetStateWait(m_Blackboard.m_AttackCooldown);
    }
}
