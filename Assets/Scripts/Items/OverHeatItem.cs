using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeatItem : BaseItem
{
    [SerializeField] private float m_Duration;
    [SerializeField] private float m_CurrentTime =  0f;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

        m_PlayerController.m_CanOverheat = false;
    }

    private void Update()
    {
        if (m_CurrentTime >= m_Duration)
        {
            m_PlayerController.m_CanOverheat = true;
            m_CurrentTime = 0;
            m_InventoryManager.UseItem();
        }

        else if (m_CurrentTime < m_Duration)
        {
            ApplyEffectItem();
            m_CurrentTime += 1 * Time.deltaTime;
        }
    }
}
