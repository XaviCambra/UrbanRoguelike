using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MeleEnemy : FSM_EnemyBase
{
    Module_AttackMele m_AttackMele;
    Module_Dash m_Dash;
    Module_Animation m_Animation;
    GameObject m_Player;
    NavMeshAgent m_NavMeshAgent;
    [SerializeField] private bool m_HasToDash;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackMele = GetComponent<Module_AttackMele>();
        m_Animation = GetComponent<Module_Animation>();
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
        m_Animation.Play("Moving", false);
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateMovement();
    }

    protected override void SetStateMovement()
    {
        base.SetStateMovement();
        m_NavMeshAgent.speed = m_Blackboard.m_RunSpeed;
        m_Animation.Play("Moving", true);
        float l_Distance = Vector3.Distance(m_Player.transform.position, transform.position);
        if (l_Distance > m_Blackboard.m_DashChargedDistance)
            m_HasToDash = true;
    }

    public override void StateMovement()
    {
        float l_Distance = Vector3.Distance(m_Player.transform.position, transform.position);
        if (l_Distance > m_Blackboard.m_DashChargedDistance)
            m_HasToDash = true;

        if (l_Distance < m_Blackboard.m_AttackDistance)
        {
            SetStateAttack();
            return;
        }

        if (l_Distance > m_Blackboard.m_DetectionRadius)
        {
            SetStateIdle();
            return;
        }

        if (m_HasToDash && l_Distance < m_Blackboard.m_DashDistance + m_Blackboard.m_AttackDistance  * 0.95f)
        {
            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_DashSound, transform.position);
            m_Animation.Play("Dash");
            m_Animation.Play("Moving", false);
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
        if(FindObjectOfType<AudioManager>() != null)
            AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_MeleeAttack1, transform.position);
        m_Animation.Play("Attack");
        m_AttackMele.HitOnDirection(m_Blackboard.m_BulletDamage);
        m_Animation.Play("Moving", false);
        SetStateWait(m_Blackboard.m_AttackRecovery);
    }
}
