using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpPerma_Heal", menuName = "Power Up/PowerUpPerma_Heal", order = 1)]
public class PowerUpPerma_Heal : PowerUp_Base
{
	public BaseItem m_HealPrefab;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_Item = m_HealPrefab;
    }
}
