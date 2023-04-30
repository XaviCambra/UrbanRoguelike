using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject m_player;
    private PlayerController m_playerController;
    private InputController m_InputController;
    [SerializeField] private GameObject m_DropItemPoint;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_playerController = m_player.GetComponent<PlayerController>();

        m_InputController = m_player.GetComponent<InputController>();
    }


    void Update()
    {
        // Descomentar para testear el DropItem()

        if (m_playerController.m_Blackboard.m_Item != null && Input.GetKeyDown(m_InputController.m_DropItemKey))
        {
            DropItem(m_playerController.m_Blackboard.m_Item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "ItemDropper") return;

        else
        {
            BaseItem l_item = other.GetComponent<BaseItem>();

            if (m_playerController.m_Blackboard.m_Item == null)
            {
                GrabItem(l_item);
                other.gameObject.SetActive(false);
            }
            
            if (m_playerController.m_Blackboard.m_Item != null && Input.GetKeyDown(m_InputController.m_SwapItemKey))
            {
                SwapItem(l_item);
            }
        }
    }

    void GrabItem(BaseItem l_item)
    {

        if (m_playerController.m_Blackboard.m_Item != null) return;

        else
        {
            m_playerController.m_Blackboard.m_Item = l_item;
        }
    }

    void SwapItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item == null) return;

        else
        {
            DropItem(m_playerController.m_Blackboard.m_Item);
            GrabItem(l_item);
        }
    }

    void DropItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item == null) return;

        else
        {
            //l_item.gameObject.SetActive(true);
            Instantiate(m_playerController.m_Blackboard.m_Item, m_DropItemPoint.transform.position, m_DropItemPoint.transform.rotation);
            UseItem();
        }
    }

    public void UseItem()
    {
        m_playerController.m_Blackboard.m_Item = null;
    }

}
