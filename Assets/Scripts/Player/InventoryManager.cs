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
    private bool m_CanDrop;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_playerController = m_player.GetComponent<PlayerController>();

        m_InputController = m_player.GetComponent<InputController>();

        m_CanSwap = false;
        m_CanDrop = false;
        m_ItemToSwap = null;
    }


    void Update()
    {
        if (m_CanDrop && Input.GetKeyDown(m_InputController.m_DropItemKey))
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
        //if (other.CompareTag("ItemDropper") || other.CompareTag("KeyDropper")) return;

        if (other.CompareTag("ItemDropper") || other.CompareTag("KeyDropper"))
        {
            BaseItem l_item = other.GetComponent<BaseItem>();

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

        else return;
    }

    public void OnTriggerExit(Collider other)
    {
        //if (other.tag != "ItemDropper") return;

        if (other.CompareTag("ItemDropper") || other.CompareTag("KeyDropper"))
        {
            m_CanSwap = false;
            m_ItemToSwap = null;
            Debug.Log("Player exited swapping radius");
        }

        else return;
    }

    public void UseItem()
    {
        m_playerController.m_Blackboard.m_Item = null;

        if (m_playerController.m_Blackboard.m_HasKey == true)
        {
            m_playerController.m_Blackboard.m_HasKey = false;
        } 
    }

    void GrabItem(BaseItem l_item)
    {

        if (m_playerController.m_Blackboard.m_Item != null) return;

        if (l_item.CompareTag("KeyDropper"))
        {
            m_playerController.m_Blackboard.m_Item = l_item;
            l_item.gameObject.SetActive(false);
            m_playerController.m_Blackboard.m_HasKey = true;
            m_CanDrop = true;
            Debug.Log("Player grabbed a key");
        }

        else if (l_item.CompareTag("ItemDropper"))
        {
            m_playerController.m_Blackboard.m_Item = l_item;
            l_item.gameObject.SetActive(false);
            m_CanDrop = true;
            Debug.Log("Player grabbed " + l_item);
        }
    }

    void SwapItem(BaseItem l_item)
    {
        Debug.Log("Swap Radius Entered");
        DropItem(m_playerController.m_Blackboard.m_Item);
        GrabItem(l_item);
    }

    void DropItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item == null) return;

        else
        {
            l_item.transform.position = m_DropItemPoint.transform.position;
            l_item.transform.rotation = m_DropItemPoint.transform.rotation;

            l_item.m_DropperCollider.isTrigger = true;
            l_item.gameObject.SetActive(true);
            m_CanDrop = false;

            Debug.Log("Player dropped " + l_item);
            UseItem();
        }
    }

}
