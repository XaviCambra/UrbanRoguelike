using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_MoveSpeed", menuName = "Power Up/PowerUp_MoveSpeed", order = 1)]
public class PowerUp_MoveSpeed : PowerUp_Base
{
	public float m_ExtraSpeed;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */

        m_BlackBoard.m_MovementSpeed += Mathf.Abs(m_ExtraSpeed);
    }
}
