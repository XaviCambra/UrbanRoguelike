using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ReloadSpeed : PowerUp_Base
{
	public float m_CoolDownReduction;

    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */

        m_BlackBoard.m_ReloadSpeed -= Mathf.Abs(m_CoolDownReduction);
    }
}
