using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController m_instance;

    private static PowerUp_Base m_PermanentPowerUp;

    public static float m_MaxPoints;
    private static int m_CurrentPoints;

    private void Awake()
    {
        if (m_instance != null)
            Destroy(gameObject);

        else
        {
            m_instance = null;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static int GetCurrentPoints()
    {
        return m_CurrentPoints;
    }

    public static bool HasMorePoints(int l_Points)
    {
        return l_Points >= m_CurrentPoints;
    }

    public static void AddPoints(int l_Points)
    {
        m_CurrentPoints += l_Points;
        Mathf.Clamp(m_CurrentPoints, 0, m_MaxPoints);
    }

    public static void SubstractPoints (int l_Points)
    {
        m_CurrentPoints -= l_Points;
        Mathf.Clamp(m_CurrentPoints, 0, m_MaxPoints);
    }

    public static void SetPowerUp(PowerUp_Base l_PowerUp)
    {
        m_PermanentPowerUp = l_PowerUp;
    }

    public static PowerUp_Base GetPowerUp()
    {
        return m_PermanentPowerUp;
    }

    public static void UsePermanentPowerUp()
    {
        if(m_PermanentPowerUp != null)
            m_PermanentPowerUp.ApplyPowerUp();
    }
}
