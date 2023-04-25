using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject m_player;
    private Player_BLACKBOARD m_BlackBoard;
    private InputController m_InputController;


    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("player");

        m_BlackBoard = m_player.GetComponent<Player_BLACKBOARD>();

        m_InputController = m_player.GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BlackBoard.m_Item != null && Input.GetKeyDown(m_InputController.m_DropItemKey))
        {
            DropItem(m_BlackBoard.m_Item);
        }
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

        }
    }

}
