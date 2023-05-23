using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_Shield", menuName = "Power Up/PowerUp_Shield", order = 1)]
public class PowerUp_Shield : PowerUp_Base
{
    public BaseItem m_ShieldItem;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        /*  Write your own code below */
        m_BlackBoard.m_Item = m_ShieldItem;
    }
}
