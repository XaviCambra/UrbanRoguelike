using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_Points", menuName = "Power Up/PowerUp_Points", order = 1)]
public class PowerUp_Points : PowerUp_Base
{
    public int  m_ExtraPoints;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_EnemyBlackboard.m_Points += Mathf.Abs(m_ExtraPoints);
    }
}
