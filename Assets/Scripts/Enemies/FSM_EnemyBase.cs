using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    protected EnemyBase_BLACKBOARD m_Blackboard;

    protected virtual void Update()
    {
        EnemyMovement();
        EnemyAttack();
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {

    }
}
