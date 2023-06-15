using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Loading : MonoBehaviour
{
    public GameObject m_PlayerHud;

    public Slider m_LoadingSlider;

    float m_Time = 0;
    float m_AlphaPanel = 1;

    private void Start()
    {
        m_PlayerHud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;

        m_LoadingSlider.value = m_Time / 3;

        if(m_Time > 3)
        {
            m_PlayerHud.SetActive(true);
            m_LoadingSlider.gameObject.SetActive(false);
            GetComponent<Image>().color = new Color(0, 0, 0, m_AlphaPanel);
            m_AlphaPanel -= Time.deltaTime;
            if (m_AlphaPanel < 0)
                gameObject.SetActive(false);
        }
    }
}
