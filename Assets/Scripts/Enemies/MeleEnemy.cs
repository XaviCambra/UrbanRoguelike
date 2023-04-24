using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    Module_AttackMele m_AttackMele;
    GameObject m_Player;
    NavMeshAgent m_NavMeshAgent;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_Blackboard.m_CanAttack = true;
    }


    public override void EnemyMovement()
    {
        if(Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance)
        {
            SetMovementDestination();
        }
    }

    public override void EnemyAttack()
    {
        
    }

    private void SetMovementDestination()
    {
        m_NavMeshAgent.SetDestination(m_Player.transform.position);

        if (Vector3.Distance(transform.position, m_Player.transform.position) < m_Blackboard.m_RunDistance)
        {
            m_NavMeshAgent.speed = m_Blackboard.m_WalkSpeed;
        }
        else
        {
            m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;
        }
    }
}
