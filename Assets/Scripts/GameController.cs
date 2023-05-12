using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController m_instance;

    private static PowerUp_Base m_PermanentPowerUp;

    public float m_MaxPoints;
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

    public static bool HasMorePoints(int l_Points)
    {
        return l_Points >= m_CurrentPoints;
    }

    public static void AddPoints(int l_Points)
    {
        m_CurrentPoints += l_Points;
    }

    public static void SubstractPoints (int l_Points)
    {
        m_CurrentPoints -= l_Points;
    }

    public static void SetPowerUp(PowerUp_Base l_PowerUp)
    {
        m_PermanentPowerUp = l_PowerUp;
    }
}
