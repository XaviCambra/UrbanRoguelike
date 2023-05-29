using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatDropper : BaseItem
{
    public OverHeatItem m_OverHeatItem;

    public override void ApplyEffectItem()
    {
        //base.ApplyEffectItem();

        /*  Write your own code below */

        m_DropperCollider = GetComponent<BoxCollider>();
        m_DropperCollider.isTrigger = true;
        m_OverHeatItem.ApplyEffectItem();
    }
}
