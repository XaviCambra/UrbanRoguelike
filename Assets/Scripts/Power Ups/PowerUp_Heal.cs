using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_Heal", menuName = "Power Up/PowerUp_Heal", order = 1)]
public class PowerUp_Heal : PowerUp_Base
{
	public BaseItem m_HealPrefab;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_Item = m_HealPrefab;
    }
}
