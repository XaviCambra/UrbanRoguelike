using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDropper : BaseItem
{
    [SerializeField] private HealItem m_HealItem;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();

        m_DropperCollider = GetComponent<BoxCollider>();
        m_DropperCollider.isTrigger = true;

        m_HealItem.ApplyEffectItem();
        m_InventoryManager.UseItem();
    }
}
