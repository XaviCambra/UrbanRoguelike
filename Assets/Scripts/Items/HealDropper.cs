using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDropper : BaseItem
{
    GameObject m_player;
    public float m_healAmount;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            m_player.GetComponent<Module_Health>().GetHeal(m_healAmount);

        }
    }
}
