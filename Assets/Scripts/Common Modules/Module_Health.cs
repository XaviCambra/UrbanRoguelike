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

    public GameController m_GameController;
    private EnemyBase_BLACKBOARD m_EnemyBlackBoard;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;

        m_GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (m_GameController == null) Debug.LogError("Custom Error - No object attached to Module_Health on " + gameObject.name + ".\nNo points will be added");

        if (gameObject.CompareTag("Enemy"))
        {
            m_EnemyBlackBoard = GetComponent<EnemyBase_BLACKBOARD>();
        }
    }

    public void TakeDamage(float l_Damage)
    {
        m_CurrentHealth -= l_Damage;

        Death();
    }
    public void GetHeal(float l_Heal)
    {
        m_CurrentHealth += l_Heal;

        if (m_CurrentHealth > m_MaxHealth) m_CurrentHealth = m_MaxHealth;

        
    }
    public virtual void Death()
    {
        if (m_CurrentHealth > 0) return;

        if(ObjectMesh == null)
        {
            Debug.LogError("Custom Error - No object attached to Module_Health on " + gameObject.name);
            return;
        }

        if (gameObject.CompareTag("Enemy"))
        {
            if (m_GameController != null) m_GameController.AddPoints(m_EnemyBlackBoard.m_Points);
        }

        ObjectMesh.SetActive(false);
    }

    public void ResetObject()
    {
        ObjectMesh.SetActive(true);
        m_CurrentHealth = m_MaxHealth;
    }
}
