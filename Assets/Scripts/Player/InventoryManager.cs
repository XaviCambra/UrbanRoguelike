using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject m_player;
    private PlayerController m_playerController;
    private InputController m_InputController;
    [SerializeField] private GameObject m_DropItemPoint;

    private BaseItem m_ItemToSwap;

    private bool m_CanSwap;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_playerController = m_player.GetComponent<PlayerController>();

        m_InputController = m_player.GetComponent<InputController>();

        m_CanSwap = false;
        m_ItemToSwap = null;
    }


    void Update()
    {
        if (m_playerController.m_Blackboard.m_Item != null && Input.GetKeyDown(m_InputController.m_DropItemKey))
        {
            DropItem(m_playerController.m_Blackboard.m_Item);
        }

        if (m_CanSwap && Input.GetKeyDown(m_InputController.m_SwapItemKey))
        {
            SwapItem(m_ItemToSwap);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "ItemDropper") return;

        else
        {
            BaseItem l_item = other.GetComponent<BaseItem>();

            Debug.Log("Player collides with " + l_item);

            if (m_playerController.m_Blackboard.m_Item == null)
            {
                GrabItem(l_item);
            }
            
            if (m_playerController.m_Blackboard.m_Item != null)
            {
                //SwapItem(l_item);
                m_CanSwap = true;
                m_ItemToSwap = l_item;
                Debug.Log("Can swap Item");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag != "ItemDropper") return;

        else
        {
            m_CanSwap = false;
            m_ItemToSwap = null;
            Debug.Log("Player exited swapping radius");
        }
    }

    public void UseItem()
    {
        m_playerController.m_Blackboard.m_Item = null;
    }

    void GrabItem(BaseItem l_item)
    {

        if (m_playerController.m_Blackboard.m_Item != null) return;

        else
        {
            m_playerController.m_Blackboard.m_Item = l_item;
            l_item.gameObject.SetActive(false);
            Debug.Log("Player grabbed " + l_item);
        }
    }

    void SwapItem(BaseItem l_item)
    {
        Debug.Log("Swap Entered");
        DropItem(m_playerController.m_Blackboard.m_Item);
        GrabItem(l_item);
    }

    void DropItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item == null) return;

        else
        {
            //Instantiate(m_playerController.m_Blackboard.m_Item, m_DropItemPoint.transform.position, m_DropItemPoint.transform.rotation);

            l_item.transform.position = m_DropItemPoint.transform.position;
            l_item.transform.rotation = m_DropItemPoint.transform.rotation;

            l_item.m_DropperCollider.isTrigger = true;
            l_item.gameObject.SetActive(true);
            Debug.Log("Player dropped " + l_item);
            UseItem();
        }
    }

}
