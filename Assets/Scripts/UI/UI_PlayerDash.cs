using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerDash : MonoBehaviour
{
    Player_BLACKBOARD m_PlayerBlackboard;
    //Slider m_Slider;
    public Image DashImage1;
    public Image DashImage2;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        //m_Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerBlackboard == null)
            return;
        /*if (m_Slider == null)
            return;
        m_Slider.maxValue = m_PlayerBlackboard.m_DashMaxCount;
        m_Slider.value = m_PlayerBlackboard.m_DashMaxCount - m_PlayerBlackboard.m_DashCount;*/

        updateDashImages();
    }

    void updateDashImages()
    {
        if (m_PlayerBlackboard.m_DashCount == 0)
        {
            DashImage1.enabled = true;

            DashImage2.enabled = true;
        }

        if (m_PlayerBlackboard.m_DashCount == 1)
        {
            DashImage1.enabled = true;

            DashImage2.enabled = false;
        }

        if (m_PlayerBlackboard.m_DashCount == 2)
        {
            DashImage1.enabled = false;

            DashImage2.enabled = false;
        }
    }
}
