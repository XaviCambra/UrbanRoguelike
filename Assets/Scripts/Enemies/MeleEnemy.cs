using System.Collections;
using System.Collections.Generic;
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


    public override void EnemyMovement()
    {
        Debug.Log(m_HasToDash);
        if (m_HasToDash)
        {
            if(Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DashDistance)
            {
                m_Dash.DashDisplacement((m_Player.transform.position - transform.position).normalized, m_Dash.m_DashDistance, m_Dash.m_DashSpeed);
                m_HasToDash = false;
                return;
            }
        }
        SetMovementDestination();
    }

    private void HasToDash()
    {
        m_HasToDash = Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DashDistance * 2;
    }

    public override void EnemyAttack()
    {
        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_Blackboard.m_AttackDistance) return;

        transform.LookAt(m_Player.transform.position);

        if (m_AttackOnCooldown == true) return;

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
        float l_Distance = Vector3.Distance(transform.position, m_Player.transform.position);

        if (l_Distance > m_Blackboard.m_DetectionRadius)
        {
            m_HasToDash = true;
            return;
        }

        else
        {
            if (l_Distance < m_Blackboard.m_FollowDistance)
            {
                m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;

                Vector3 l_ClosestPointOnPlayer = m_Player.transform.position - (m_Player.transform.position - transform.position).normalized * (m_Blackboard.m_AttackDistance * 0.95f);
                m_NavMeshAgent.SetDestination(l_ClosestPointOnPlayer);
            }

            if (l_Distance < m_Blackboard.m_AttackDistance)
            {
                EnemyAttack();
            }
        }
    }
}
