using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Health : MonoBehaviour
{
    [Header("Statistics")]
    public float m_MaxHealth;
    public float m_CurrentHealth;

    [Header("Object Model")]
    public GameObject ObjectMesh;

    public delegate void PlayerIsDead(bool isDead);
    public PlayerIsDead m_PlayerIsDead;

    public GameController m_GameController;
    private EnemyBase_BLACKBOARD m_EnemyBlackBoard;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;

        m_GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (gameObject.CompareTag("Enemy"))
        {
            m_EnemyBlackBoard = GetComponent<EnemyBase_BLACKBOARD>();
        }
    }

    public void TakeDamage(float l_Damage)
    {
        Debug.Log(gameObject.name + " losses " + l_Damage + "hp");
        m_CurrentHealth -= l_Damage;

        Death();
    }
    public void GetHeal(float l_Heal)
    {
        if (m_CurrentHealth == m_MaxHealth)
        {
            Debug.Log(gameObject.name + " can't get healed.");
            Debug.Log(gameObject.name + " has health: " + m_CurrentHealth);
            return;
        }
        
        m_CurrentHealth += l_Heal;

        if (m_CurrentHealth > m_MaxHealth) m_CurrentHealth = m_MaxHealth;

        Debug.Log(gameObject.name + " recieved heal: " + l_Heal);
        Debug.Log(gameObject.name + " has health: " + m_CurrentHealth);
        
    }
    public void Death()
    {
        if (m_CurrentHealth > 0) return;

        if(ObjectMesh == null)
        {
            Debug.LogError("Custom Error - No object attached to Module_Health on " + gameObject.name);
            return;
        }

        if (gameObject.CompareTag("Enemy"))
        {
            m_GameController.AddPoints(m_EnemyBlackBoard.m_Points);
        }

        Debug.Log(gameObject.name + " is dead");
        m_PlayerIsDead?.Invoke(true);
        ObjectMesh.SetActive(false);
    }

    public void ResetObject()
    {
        ObjectMesh.SetActive(true);
        m_PlayerIsDead?.Invoke(false);
        m_CurrentHealth = m_MaxHealth;
    }
}
