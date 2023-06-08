using UnityEngine;

public class ShieldItem : BaseItem
{
    private PlayerController m_PlayerController;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        m_PlayerController.StartInmortality(m_PlayerController.m_Blackboard.m_InmortalityDuration);
    }
}
