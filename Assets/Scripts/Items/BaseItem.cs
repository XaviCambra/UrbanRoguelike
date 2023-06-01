using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public InventoryManager m_InventoryManager;
    public BoxCollider m_DropperCollider;

    public GameObject m_FloatingText;
    public virtual void ApplyEffectItem()
    {
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        m_InventoryManager.UseItem();
    }

    private void Start()
    {
        m_FloatingText.SetActive(false);
    }

    public void ActivateText()
    {
        m_FloatingText.SetActive(true);
    }

    public void DeactivateText()
    {
        m_FloatingText.SetActive(false);
    }

}
