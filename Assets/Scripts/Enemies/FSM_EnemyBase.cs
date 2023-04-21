using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    EnemyBase_BLACKBOARD m_Blackboard;

    private void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
    }

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
