using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    protected EnemyBase_BLACKBOARD m_Blackboard;
    public bool m_IsKnockback;

    protected virtual void Update()
    {
        if (m_IsKnockback)
        {
            GetKnockback(Vector3.zero, 0);
            return;
        }
        EnemyMovement();
        EnemyAttack();
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {
        //if (m_Blackboard.m_CanAttack == false) return;
    }

    public void GetKnockback(Vector3 l_PushDirection, float l_PushForce)
    {
        
    }
}
