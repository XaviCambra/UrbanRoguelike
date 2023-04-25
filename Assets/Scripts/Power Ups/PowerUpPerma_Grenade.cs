using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPerma_Grenade : PowerUp_Base
{
    public BaseItem m_GrenadePrefab;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */

        m_BlackBoard.m_Item = m_GrenadePrefab;

    }
}
