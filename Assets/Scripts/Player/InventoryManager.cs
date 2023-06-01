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
        if (other.CompareTag("ItemDropper") || other.CompareTag("KeyDropper"))
        {
            BaseItem l_item = other.GetComponent<BaseItem>();

            if (m_playerController.m_Blackboard.m_Item == null)
            {
                GrabItem(l_item);
            }

            if (m_playerController.m_Blackboard.m_Item != null)
            {
                l_item.ActivateText();
                m_CanSwap = true;
                m_ItemToSwap = l_item;
            }
        }

        if (other.CompareTag("Fingerprint"))
        {
            FingerprintTrigger l_item = other.GetComponent<FingerprintTrigger>();

            l_item.SetActive();
            l_item.ActivateText();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ItemDropper") || other.CompareTag("KeyDropper"))
        {
            BaseItem l_item = other.GetComponent<BaseItem>();
            l_item.DeactivateText();
            m_CanSwap = false;
            m_ItemToSwap = null;
        }
    }

    public void UseItem()
    {
        m_playerController.m_Blackboard.m_Item = null;
    }

    void GrabItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item != null)
            return;

        if (!l_item.CompareTag("ItemDropper"))
            return;

        m_playerController.m_Blackboard.m_Item = l_item;
        l_item.gameObject.SetActive(false);
        m_CanDrop = true;
    }

    void SwapItem(BaseItem l_item)
    {
        DropItem(m_playerController.m_Blackboard.m_Item);
        l_item.DeactivateText();
        GrabItem(l_item);
    }

    void DropItem(BaseItem l_item)
    {
        if (m_playerController.m_Blackboard.m_Item == null)
            return;

        l_item.transform.position = m_DropItemPoint.transform.position;
        l_item.transform.rotation = m_DropItemPoint.transform.rotation;

        m_CanDrop = false;

        l_item.DeactivateText();
        l_item.gameObject.SetActive(true);
        l_item.m_DropperCollider.isTrigger = true;
        UseItem();
    }

}
