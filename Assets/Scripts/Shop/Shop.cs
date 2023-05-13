using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<PowerUp_Base> m_AllPowerUpList;

    public List<PowerUp_Base> m_ShopList;

    public PowerUpCard[] m_CardsShop;

    public void RandomPowerUps(List<PowerUp_Base> l_PowerUpList)
    {
        m_ShopList.Clear();
        if(l_PowerUpList.Count <= 0) return;

        if(l_PowerUpList.Count <= m_CardsShop.Length)
        {
            m_ShopList = l_PowerUpList;
        }
        else
        {
            for(int i = 0; i < m_CardsShop.Length; i++)
            {
                m_ShopList.Add(GiveRandomPower(l_PowerUpList));
            }
        }

        AddShopListToCards();
    }

    private PowerUp_Base GiveRandomPower(List<PowerUp_Base> l_PowerUpList)
    {
        PowerUp_Base powerUp = l_PowerUpList[Random.Range(0, l_PowerUpList.Count)];
        if (m_ShopList.Contains(powerUp))
        {
            return GiveRandomPower(l_PowerUpList);
        }
        return powerUp;
    }

    private void AddShopListToCards()
    {
        foreach(PowerUpCard l_Card in m_CardsShop)
        {
            l_Card.gameObject.SetActive(false);
        }
        for(int i = 0; i < m_CardsShop.Length; i++)
        {
            m_CardsShop[i].SetPower(m_ShopList[i]);
            m_CardsShop[i].gameObject.SetActive(true);
        }
    }
}
