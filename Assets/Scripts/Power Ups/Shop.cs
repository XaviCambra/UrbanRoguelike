using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<PowerUp_Base> m_AllPowerUpList;

    private List<PowerUp_Base> m_NotPickedPowerUps;
    private List<PowerUp_Base> m_PickedPowerUps;

    private List<PowerUp_Base> m_ShopList;

    public int m_ShopListCount;
    public GameObject[] m_CardsShop;

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
    }

    public void RandomPowerUps()
    {
        if(m_NotPickedPowerUps.Count <= 0) return;

        if(m_NotPickedPowerUps.Count <= m_ShopListCount)
        {
            m_ShopList = m_NotPickedPowerUps;
        }
        else
        {
            for(int i = 0; i < m_ShopListCount; i++)
            {
                m_ShopList.Add(GiveRandomPower());
            }
        }
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
}
