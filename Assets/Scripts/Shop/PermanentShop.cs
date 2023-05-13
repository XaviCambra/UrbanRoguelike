using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PermanentShop : Shop
{
    public List<PowerUp_Base> m_NotPickedPowerUps;

    void Start()
    {
        ClearPowerUpsList();
    }

    private void ClearPowerUpsList()
    {
        m_NotPickedPowerUps = m_AllPowerUpList;

        RandomPowerUps(m_NotPickedPowerUps);
    }

    public void BuyPowerUp(int l_PowerUpIndex)
    {
        if (PlayerPrefs.GetInt(m_ShopList[l_PowerUpIndex].m_PowerUp_Name) == 1)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SetPowerUp(m_ShopList[l_PowerUpIndex]);
            return;
        }
        if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().HasMorePoints(m_ShopList[l_PowerUpIndex].m_PowerUp_Price)) return;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SubstractPoints(m_ShopList[l_PowerUpIndex].m_PowerUp_Price);
        PlayerPrefs.SetInt(m_ShopList[l_PowerUpIndex].m_PowerUp_Name, 1);

        ClearPowerUpsList();
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
