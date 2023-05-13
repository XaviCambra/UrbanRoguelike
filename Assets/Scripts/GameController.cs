using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController m_instance;

    public PowerUp_Base m_PermanentPowerUp;

    public int m_MaxPoints;
    public int m_CurrentPoints;

    private void Awake()
    {
        if (m_instance != null)
            Destroy(gameObject);
        else
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentPoints()
    {
        return m_CurrentPoints;
    }

    public bool HasMorePoints(int l_Points)
    {
        return l_Points <= m_CurrentPoints;
    }

    public void AddPoints(int l_Points)
    {
        m_CurrentPoints += l_Points;
        Mathf.Clamp(m_CurrentPoints, 0, m_MaxPoints);
    }

    public void SubstractPoints (int l_Points)
    {
        m_CurrentPoints -= l_Points;
        Mathf.Clamp(m_CurrentPoints, 0, m_MaxPoints);
    }

    public void SetPowerUp(PowerUp_Base l_PowerUp)
    {
        m_PermanentPowerUp = l_PowerUp;
    }

    public PowerUp_Base GetPowerUp()
    {
        return m_PermanentPowerUp;
    }

    public void UsePermanentPowerUp()
    {
        if(m_PermanentPowerUp != null)
            m_PermanentPowerUp.ApplyPowerUp();
    }
}
