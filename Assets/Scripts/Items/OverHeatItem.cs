using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeatItem : BaseItem
{

    private PlayerController m_PlayerController;

    [SerializeField] private float m_Duration;
    [SerializeField] private float m_CurrentTime =  0f;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        m_PlayerController.m_OverheatCancelled = true;
        Debug.Log("Over Heat Item Used");
    }
}
