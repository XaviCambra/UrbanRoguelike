using UnityEngine;

public class ShieldDropper : BaseItem
{
    [SerializeField] private ShieldItem m_ShieldItem;
    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();

        m_DropperCollider = GetComponent<BoxCollider>();
        m_DropperCollider.isTrigger = true;

        m_ShieldItem.ApplyEffectItem();
        m_InventoryManager.UseItem();
    }
}
