using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_KillerMode", menuName = "Power Up/PowerUp_KillerMode", order = 1)]
public class PowerUp_KillerMode : PowerUp_Base
{
	public BaseItem m_KillerModePrefab;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_Item = m_KillerModePrefab;
    }
}
