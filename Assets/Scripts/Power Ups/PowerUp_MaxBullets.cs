using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_MaxBullets", menuName = "Power Up/PowerUp_MaxBullets", order = 1)]
public class PowerUp_MaxBullets : PowerUp_Base
{
	public float m_BulletIncrease;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_MaxOverHeat += Mathf.Abs(m_BulletIncrease);
    }
}
