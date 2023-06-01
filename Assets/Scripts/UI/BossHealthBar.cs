using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public GameObject m_SliderObject;
    private Slider m_Slider;
    public EnemyBase_BLACKBOARD m_Blackboard;
    public Module_Health m_Health;

    private void Start()
    {
        m_Slider = m_SliderObject.GetComponent<Slider>();
    }


    // Update is called once per frame
    void Update()
    {
        m_SliderObject.SetActive(m_Blackboard.m_IsActive);
        m_Slider.value = m_Health.GetHealthPercent();
    }
}
