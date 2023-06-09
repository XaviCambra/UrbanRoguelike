using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeatItem : BaseItem
{
    private PlayerController m_PlayerController;
    public override void ApplyEffectItem()
    {
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        m_PlayerController.StartKillerMode();
        base.ApplyEffectItem();
    }
}
