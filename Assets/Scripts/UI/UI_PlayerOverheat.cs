using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerOverheat : MonoBehaviour
{
    Player_BLACKBOARD m_PlayerBlackboard;
    Slider m_Slider;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        m_Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerBlackboard == null)
            return;
        if (m_Slider == null)
            return;
        m_Slider.maxValue = m_PlayerBlackboard.m_MaxOverHeat;
        m_Slider.value = m_PlayerBlackboard.m_MaxOverHeat - m_PlayerBlackboard.m_CurrentShots;
    }
}
