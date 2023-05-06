using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpCard : MonoBehaviour
{
    public PowerUp_Base m_PowerUp;

    public TextMeshProUGUI m_CardName;
    public Image m_CardSprite;
    public TextMeshProUGUI m_CardDescription;

    public void SetPower(PowerUp_Base l_PowerUp)
    {
        m_PowerUp = l_PowerUp;
        SetCardStats();
    }

    public void SetCardStats()
    {
        m_CardName.text = m_PowerUp.PowerUp_Name;
        m_CardSprite.sprite = m_PowerUp.PowerUp_Image;
        m_CardDescription.text = m_PowerUp.PowerUp_Description;
    }
}
