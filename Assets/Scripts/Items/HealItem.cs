using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{
    [SerializeField] private float m_HealAmount;
    public override void ApplyEffectItem()
    {
        
        base.ApplyEffectItem();

        /*  Write your own code below */

        m_PlayerHealth.GetHeal(m_HealAmount);

        m_InventoryManager.UseItem();
    }
}
