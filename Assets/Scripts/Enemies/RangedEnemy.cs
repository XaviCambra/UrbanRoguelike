using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_PlayerHitpoint;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");

        m_Blackboard.m_CanAttack = true;
    }

    protected override void Update()
    {
        base.Update();

        m_Blackboard.m_AttackPoint.transform.LookAt(m_PlayerHitpoint.transform);
    }

    public override void EnemyMovement()
    {
        base.EnemyMovement();
        Vector3 l_LookAtPlayer = m_Player.transform.position;
        transform.LookAt(l_LookAtPlayer);
    }

    public override void EnemyAttack()
    {
        //base.EnemyAttack();
        if (m_Blackboard.m_CanAttack == false) return;
        m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage);
        m_Blackboard.m_CanAttack = false;
        StartCoroutine(RechargeAttack());
    }

    protected IEnumerator RechargeAttack()
    {
        float l_RechargeAttack = m_Blackboard.m_AttackCooldown + Random.Range(-0.5f, 0.5f);
        yield return new WaitForSeconds(l_RechargeAttack);
        m_Blackboard.m_CanAttack = true;
    }
}
