using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalShop : Shop
{
    void Start()
    {
        RandomPowerUps(m_AllPowerUpList);
    }

    public void OneUsePowerUp(int l_PowerUpIndex)
    {
        m_ShopList[l_PowerUpIndex].ApplyPowerUp();
        CloseShop();
    }

    public void CloseShop()
    {
        SceneLoader.UnLoadScene("InGamePowerUp");
    }
}
