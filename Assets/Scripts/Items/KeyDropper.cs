using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDropper : BaseItem
{
    public KeyItem m_KeyItem;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();

        m_DropperCollider = GetComponent<BoxCollider>();
        m_DropperCollider.isTrigger = true;

        Debug.Log("KeyDropped sent signal");
        m_KeyItem.ApplyEffectItem();
    }
}
