using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHP : MonoBehaviour
{
    Player_Health m_PlayerHealth;
    Slider m_Slider;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        m_Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerHealth == null)
            return;
        if (m_Slider == null)
            return;
        m_Slider.maxValue = m_PlayerHealth.m_MaxHealth;
        m_Slider.value = m_PlayerHealth.m_CurrentHealth;
    }
}
