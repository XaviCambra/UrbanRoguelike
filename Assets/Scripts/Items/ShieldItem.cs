using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : BaseItem
{
    private PlayerController m_PlayerController;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        m_PlayerController.Inmortality(m_PlayerController.m_Blackboard.m_InmortalityDuration);
    }
}
