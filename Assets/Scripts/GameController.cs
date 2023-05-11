using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController m_instance;

    public PowerUp_Base m_PermanentPowerUp;

    public float m_MaxPoints;
    public float m_CurrentPoints;

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

    public void AddPoints(float l_points)
    {
        m_CurrentPoints += l_points;
    }

    public void SubstractPoints (float l_points)
    {
        m_CurrentPoints -= l_points;
    }

    public void SetPowerUp()
    {

    }
}
