using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public InventoryManager m_InventoryManager;
    public BoxCollider m_DropperCollider;

    public GameObject m_FloatingText;
    public virtual void ApplyEffectItem()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Player_BLACKBOARD l_blackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        if (other.CompareTag("Player") && l_blackboard.m_Item != null)
        {
            m_FloatingText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player_BLACKBOARD l_blackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        if (other.CompareTag("Player") && l_blackboard.m_Item != null)
        {
            m_FloatingText.SetActive(false);
        }
    }*/

    public void ActivateText()
    {
        m_FloatingText.SetActive(true);
    }

    public void DeactivateText()
    {
        m_FloatingText.SetActive(false);
    }

}
