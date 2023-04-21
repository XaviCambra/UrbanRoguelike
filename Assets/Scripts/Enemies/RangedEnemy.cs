using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    PlayerController m_Player;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        m_Blackboard.m_CanAttack = true;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void EnemyMovement()
    {
        base.EnemyMovement();
        Vector3 l_LookAtPlayer = m_Player.transform.position;
        l_LookAtPlayer.y = 0.5f;
        transform.LookAt(l_LookAtPlayer);
    }

    public override void EnemyAttack()
    {
        //base.EnemyAttack();
        if (m_Blackboard.m_CanAttack == false) return;
        m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Player.transform.position, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage);
        Debug.Log(m_Blackboard.m_CanAttack);
        m_Blackboard.m_CanAttack = false;
        StartCoroutine(RechargeAttack());
    }

    protected IEnumerator RechargeAttack()
    {
        yield return new WaitForSeconds(m_Blackboard.m_AttackCooldown);
        m_Blackboard.m_CanAttack = true;
    }
}
