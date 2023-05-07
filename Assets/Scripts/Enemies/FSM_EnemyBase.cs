using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    protected EnemyBase_BLACKBOARD m_Blackboard;
    private bool m_IsActive = true;

    protected virtual void Update()
    {
        if (m_IsActive == false) return;
        EnemyMovement();
        EnemyAttack();
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {

    }

    private void SetInnactiveObject()
    {
        m_IsActive = false;
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().m_PlayerIsDead += SetInnactiveObject;
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().m_PlayerIsDead -= SetInnactiveObject;
    }
}
