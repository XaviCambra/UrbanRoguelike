using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDropper : BaseItem
{
    public KeyItem m_Key;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_Key.ApplyEffectItem();
    }
}
