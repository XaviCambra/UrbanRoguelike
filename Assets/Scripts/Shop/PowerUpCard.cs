using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpCard : MonoBehaviour
{
    public PowerUp_Base m_PowerUp;

    public Color m_OwnedColor;
    public Color m_ActiveColor;

    public int m_CardIndex;
    public TextMeshProUGUI m_CardName;
    public Image m_CardSprite;
    public TextMeshProUGUI m_CardDescription;
    public TextMeshProUGUI m_CardPrice;

    public void SetPower(PowerUp_Base l_PowerUp)
    {
        m_PowerUp = l_PowerUp;
        SetCardStats();
    }

    public void SetCardStats()
    {
        if(m_CardName != null)
            m_CardName.text = m_PowerUp.m_PowerUp_Name;
        if(m_CardSprite != null)
            m_CardSprite.sprite = m_PowerUp.m_PowerUp_Image;
        if(m_CardDescription != null)
            m_CardDescription.text = m_PowerUp.m_PowerUp_Description;
        if (m_CardPrice == null)
            return;

        Image l_CardImage = GetComponent<Image>();

        if (PlayerPrefs.GetInt(m_PowerUp.m_PowerUp_Name) == 1)
        {
            if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetPowerUp() != null &&
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetPowerUp().m_PowerUp_Name.Equals(m_PowerUp.m_PowerUp_Name))
            {
                if (l_CardImage != null)
                    l_CardImage.color = m_ActiveColor;
                m_CardPrice.text = "Activo";
            }
            else
            {
                if (l_CardImage != null)
                    l_CardImage.color = m_OwnedColor;
                m_CardPrice.text = "Activar";
            }
        }
        else
        {
            m_CardPrice.text = m_PowerUp.m_PowerUp_Price.ToString();
            if (l_CardImage != null)
                l_CardImage.color = Color.white;
        }
    }
}
