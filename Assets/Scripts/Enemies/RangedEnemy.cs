using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    Module_Crouch m_Crouch;
    GameObject m_PlayerHitpoint;

    //EnemyBase_BLACKBOARD m_BlackBoard;

    public GameObject m_Player;

    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_Crouch = GetComponent<Module_Crouch>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
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
        l_LookAtPlayer.y = transform.position.y;
        transform.LookAt(l_LookAtPlayer);
    }

    public override void EnemyAttack()
    {
        base.EnemyAttack();
        if (m_Blackboard.m_CanAttack == false) return;
        m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage, "Enemy");
        m_Blackboard.m_CanAttack = false;
        StartCoroutine(CrouchIn());
    }

    private IEnumerator CrouchIn()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Crouch");
        m_Crouch.AlternateCrouching(false);
        StartCoroutine(RechargeAttack());
    }

    protected IEnumerator RechargeAttack()
    {
        float l_RechargeAttack = m_Blackboard.m_AttackCooldown + Random.Range(-0.75f, 0.75f);
        yield return new WaitForSeconds(l_RechargeAttack);
        StartCoroutine(CrouchOut());
    }

    private IEnumerator CrouchOut()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Crouch Out");
        m_Crouch.AlternateCrouching(true);
        m_Blackboard.m_CanAttack = true;
    }
}
