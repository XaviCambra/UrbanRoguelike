using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    Module_AttackMele m_AttackMele;
    [SerializeField] GameObject m_Player;
    NavMeshAgent m_NavMeshAgent;

    private bool m_CanMove;
    private bool m_CanAttack;

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
        transform.forward = m_NavMeshAgent.velocity.normalized;

        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance)
        {
            SetMovementDestination();
        }
    }

    public override void EnemyAttack()
    {
        m_CanMove = Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_AttackDistance;

        m_AttackMele.HitOnDirection(m_Blackboard.m_Damage);
        StartCoroutine(RechargeAttack());
    }

    private IEnumerator RechargeAttack()
    {
        m_CanAttack = false;
        yield return new WaitForSeconds(m_Blackboard.m_AttackCooldown);
        m_CanAttack = true;
    }

    private void SetMovementDestination()
    {
        m_NavMeshAgent.SetDestination(m_Player.transform.position);
        m_NavMeshAgent.updateRotation = true;

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
