using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentShop : Shop
{
    public List<PowerUp_Base> m_NotPickedPowerUps;
    public List<PowerUp_Base> m_PickedPowerUps = new List<PowerUp_Base>();

    void Start()
    {
        m_NotPickedPowerUps = m_AllPowerUpList;

        foreach (PowerUp_Base l_PowerUp in m_AllPowerUpList)
        {
            if (PlayerPrefs.GetInt(l_PowerUp.m_PowerUp_Name) != 0)
            {
                m_PickedPowerUps.Add(l_PowerUp);
            }
        }

        if (m_PickedPowerUps.Count > 0)
        {
            foreach (PowerUp_Base l_PickedPower in m_PickedPowerUps)
            {
                if (m_NotPickedPowerUps.Contains(l_PickedPower))
                {
                    m_NotPickedPowerUps.Remove(l_PickedPower);
                }
            }
        }


        RandomPowerUps(m_NotPickedPowerUps);
    }

    public void BuyPowerUp(int l_PowerUpIndex)
    {
        if (GameController.HasMorePoints(m_ShopList[l_PowerUpIndex].m_PowerUp_Price) == false) return;
        GameController.SubstractPoints(m_ShopList[l_PowerUpIndex].m_PowerUp_Price);
        PlayerPrefs.SetInt(m_ShopList[l_PowerUpIndex].m_PowerUp_Name, 1);
    }
}