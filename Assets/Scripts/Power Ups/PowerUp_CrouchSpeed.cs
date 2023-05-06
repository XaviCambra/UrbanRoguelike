using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_CrouchSpeed", menuName = "Power Up/PowerUp_CrouchSpeed", order = 1)]
public class PowerUp_CrouchSpeed : PowerUp_Base
{
	public float m_SpeedIncrease;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_CrouchingSpeed += Mathf.Abs(m_SpeedIncrease);
    }
}

