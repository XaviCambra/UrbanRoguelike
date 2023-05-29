using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    GameObject m_PlayerHitpoint;
    LineRenderer m_LineRenderer;

    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");
        m_LineRenderer = GetComponent<LineRenderer>();

        m_IsActive = false;
    }


}
