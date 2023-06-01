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
    private float m_TimeSinceWin;

    private void Start()
    {
        m_Slider = m_SliderObject.GetComponent<Slider>();
    }


    // Update is called once per frame
    void Update()
    {
        m_SliderObject.SetActive(m_Blackboard.m_IsActive);
        m_Slider.value = m_Health.GetHealthPercent();

        if (m_Health.GetHealthPercent() > 0)
            return;

        Debug.Log("Timer activated");
        if(m_TimeSinceWin <= 3)
        {
            Debug.Log("Timer done");
            SceneLoader.LoadScene("Victory");
        }
        m_TimeSinceWin += Time.deltaTime;
    }
}
