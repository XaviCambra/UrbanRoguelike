using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeatItem : BaseItem
{
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private float m_Duration;
    private float m_CurrentTime =  0f;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

        if (m_CurrentTime < m_Duration)
        {
            m_playerController.m_CanOverheat = false;
        }

        else m_CurrentTime += 1 * Time.deltaTime;

    }
}
