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
    private bool m_AttackOnCooldown;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        m_Blackboard.m_CanAttack = true;
        m_AttackOnCooldown = false;
    }


    public override void EnemyMovement()
    {
        m_CanMove = Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance;

        if (m_CanMove == false) return;
        
        SetMovementDestination();
        transform.LookAt(m_NavMeshAgent.velocity.normalized);
    }

    public override void EnemyAttack()
    {
        m_CanAttack = Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_AttackDistance;

        if (m_CanAttack == false) return;

        transform.LookAt(m_Player.transform.position);

        if (m_AttackOnCooldown == true) return;

        transform.LookAt(m_Player.transform.position);
        m_AttackMele.HitOnDirection(m_Blackboard.m_Damage);
        m_AttackOnCooldown = true;
        StartCoroutine(RechargeAttack());
    }

    private IEnumerator RechargeAttack()
    {
        yield return new WaitForSeconds(m_Blackboard.m_AttackCooldown);
        m_AttackOnCooldown = false;
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
