using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public InventoryManager m_InventoryManager;
    public PlayerController m_PlayerController;
    public Module_Health m_PlayerHealth;
    public virtual void ApplyEffectItem()
    {
        
    }

    private void Start()
    {
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        m_PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Module_Health>();
    }

}
