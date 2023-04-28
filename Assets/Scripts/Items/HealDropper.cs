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

        m_HealItem.ApplyEffectItem();
    }
}
