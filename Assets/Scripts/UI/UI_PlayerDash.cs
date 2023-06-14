using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerDash : MonoBehaviour
{
    Player_BLACKBOARD m_PlayerBlackboard;

    public List<Image> DashImageList;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        for (int i = 0; i < DashImageList.Count; i++)
        {
            DashImageList[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerBlackboard == null)
            return;

        updateDashImages();
    }

    void updateDashImages()
    {
        for (int i = 0; i < m_PlayerBlackboard.m_DashMaxCount; i++)
        {
            DashImageList[i].enabled = true;
        }

        for (int i = 0; i < m_PlayerBlackboard.m_DashCount; i++)
        {
            DashImageList[i].enabled = false;
        }
    }
}
