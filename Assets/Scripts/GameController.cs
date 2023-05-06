using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController m_instance;

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
        Debug.Log("Player recibe: " + l_points + " puntos. Puntos actuales: " + m_CurrentPoints);
    }

    public void SubstractPoints (float l_points)
    {
        m_CurrentPoints -= l_points;
        Debug.Log("Player gasta: " + l_points + " puntos. Puntos actuales: " + m_CurrentPoints);
    }

}
