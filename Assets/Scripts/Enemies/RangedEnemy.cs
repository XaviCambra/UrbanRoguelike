using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{

    public bool m_CanAttack;


    protected override void Update()
    {
        base.Update();
    }

    public override void EnemyMovement()
    {
        if (Cover()) return;
    }

    public override void EnemyAttack()
    {
        if (m_CanAttack == false) return;


    }

    private bool Cover()
    {
        bool l_IsCovering;

        l_IsCovering = false;

        return l_IsCovering;
    }
}
