using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : BaseItem
{

    private Module_Health m_PlayerHealth;
    [SerializeField] private float m_HealAmount;
    public override void ApplyEffectItem()
    {
        
        base.ApplyEffectItem();

        /*  Write your own code below */

        m_PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Module_Health>();

        if (m_PlayerHealth.m_CurrentHealth == m_PlayerHealth.m_MaxHealth) return;

        else
        {
            m_PlayerHealth.GetHeal(m_HealAmount);

            m_InventoryManager.UseItem();
        }
    }
}
