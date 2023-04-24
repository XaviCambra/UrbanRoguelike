using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_AttackDamage : PowerUp_Base
{
	public float m_DamageIncrease;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_ShootingDamage += Mathf.Abs(m_DamageIncrease);

    }
}
