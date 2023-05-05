using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject m_player;
    private Player_BLACKBOARD m_BlackBoard;
    private InputController m_InputController;
    [SerializeField] private GameObject m_DropItemPoint;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_BlackBoard = m_player.GetComponent<Player_BLACKBOARD>();

        m_InputController = m_player.GetComponent<InputController>();
    }


    void Update()
    {
        // Descomentar para testear el DropItem()

        /*if (m_BlackBoard.m_Item != null && Input.GetKeyDown(m_InputController.m_DropItemKey))
        {
            DropItem(m_BlackBoard.m_Item);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "ItemDropper") return;

        else
        {
            BaseItem l_item = other.GetComponent<BaseItem>();

            if (m_BlackBoard.m_Item == null)
            {
                GrabItem(l_item);
                other.gameObject.SetActive(false);
            }
            
            if (m_BlackBoard.m_Item != null && Input.GetKeyDown(m_InputController.m_SwapItemKey))
            {
                SwapItem(l_item);
            }
        }
    }

    void GrabItem(BaseItem l_item)
    {

        if (m_BlackBoard.m_Item != null) return;

        else
        {
            m_BlackBoard.m_Item = l_item;
        }
    }

    void SwapItem(BaseItem l_item)
    {
        if (m_BlackBoard.m_Item == null) return;

        else
        {
            DropItem(m_BlackBoard.m_Item);
            GrabItem(l_item);
        }
    }

    void DropItem(BaseItem l_item)
    {
        if (m_BlackBoard.m_Item == null) return;

        else
        {
            Instantiate(m_BlackBoard.m_Item, m_DropItemPoint.transform.position, m_DropItemPoint.transform.rotation);
            m_BlackBoard.m_Item = null;
        }
    }

}
