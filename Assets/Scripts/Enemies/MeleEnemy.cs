using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    private Module_AttackMele m_AttackMele;
    private NavMeshAgent m_NavMeshAgent;

    [SerializeField] private bool m_CanMove;
    [SerializeField] private bool m_CanAttack;

    public EnemyBase_BLACKBOARD m_BlackBoard;

    public GameObject m_Player;

    float m_VectorDistance;

    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        //m_AttackMele.DeactivateCollisionDetection();

        m_CanMove = true;
        m_CanAttack = true;
    }

    protected override void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        m_VectorDistance = Vector3.Distance(m_Player.transform.position, transform.position);

        if (m_VectorDistance > m_BlackBoard.m_DetectionRadius)
        {
            //m_CanMove = true;
            m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;
            EnemyMovement();
        }

        if (m_VectorDistance <= m_BlackBoard.m_DetectionRadius)
        {
            //m_CanMove = true;
            m_NavMeshAgent.speed = m_Blackboard.m_WalkSpeed;
            EnemyMovement();
        }

        else return;
    }

    public override void EnemyMovement()
    {
        //m_CanMove = Vector3.Distance(m_Player.transform.position, transform.position) > m_BlackBoard.m_AttackRadius;

        transform.LookAt(m_Player.transform.position);

        if (m_CanMove == false) return;

        SetMovementDestination();
        transform.LookAt(m_NavMeshAgent.velocity.normalized);

        if (m_VectorDistance <= m_BlackBoard.m_AttackRadius)
        {
            //m_CanAttack = true;
            EnemyAttack();
        }
    }

    public override void EnemyAttack()
    {
        //m_CanAttack = Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_AttackRadius;

        if (m_CanAttack == false) return;

        m_CanMove = false;

        Debug.Log("Attack");
        m_AttackMele.HitOnDirection(m_Blackboard.m_Damage);

        m_CanMove = true;

        StartCoroutine(RechargeAttack());
    }

    private IEnumerator RechargeAttack()
    {
        Debug.Log("Recharging attack");
        m_CanAttack = false;
        yield return new WaitForSeconds(m_Blackboard.m_AttackCooldown);
        m_CanAttack = true;
    }

    private void SetMovementDestination()
    {
        m_NavMeshAgent.SetDestination(m_Player.transform.position);

        /*if (Vector3.Distance(transform.position, m_BlackBoard.m_Player.transform.position) < m_Blackboard.m_RunDistance)
        {
            m_NavMeshAgent.speed = m_Blackboard.m_WalkSpeed;
        }
        else
        {
            m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;
        }*/
    }
}
