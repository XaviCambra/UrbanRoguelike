using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<PowerUp_Base> m_AllPowerUpList;

    public List<PowerUp_Base> m_NotPickedPowerUps;
    public List<PowerUp_Base> m_PickedPowerUps = new List<PowerUp_Base>();

    public List<PowerUp_Base> m_ShopList;

    public PowerUpCard[] m_CardsShop;

    private void Start()
    {
        m_NotPickedPowerUps = m_AllPowerUpList;

        if (m_PickedPowerUps.Count <= 0) return;
        foreach(PowerUp_Base l_PickedPower in m_PickedPowerUps)
        {
            if (m_NotPickedPowerUps.Contains(l_PickedPower))
            {
                m_NotPickedPowerUps.Remove(l_PickedPower);
            }
        }

        RandomPowerUps();
    }

    public void RandomPowerUps()
    {
        m_ShopList.Clear();
        if(m_NotPickedPowerUps.Count <= 0) return;

        if(m_NotPickedPowerUps.Count <= m_CardsShop.Length)
        {
            m_ShopList = m_NotPickedPowerUps;
        }
        else
        {
            for(int i = 0; i < m_CardsShop.Length; i++)
            {
                m_ShopList.Add(GiveRandomPower());
            }
        }

        AddShopListToCards();
    }

    private PowerUp_Base GiveRandomPower()
    {
        PowerUp_Base powerUp = m_NotPickedPowerUps[Random.Range(0, m_NotPickedPowerUps.Count)];
        if (m_ShopList.Contains(powerUp))
        {
            return GiveRandomPower();
        }
        return powerUp;
    }

    private void AddShopListToCards()
    {
        for(int i = 0; i < m_CardsShop.Length; i++)
        {
            m_CardsShop[i].SetPower(m_ShopList[i]);
        }
    }
}
