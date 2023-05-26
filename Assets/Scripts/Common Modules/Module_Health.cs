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

    private EnemyBase_BLACKBOARD m_EnemyBlackBoard;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;

        if (gameObject.CompareTag("Enemy"))
        {
            m_EnemyBlackBoard = GetComponent<EnemyBase_BLACKBOARD>();
        }
    }

    public virtual void TakeDamage(float l_Damage)
    {
        m_CurrentHealth -= l_Damage;

        if(m_CurrentHealth <= 0)
            Death();
    }

    public void GetHeal(float l_Heal)
    {
        m_CurrentHealth += l_Heal;

        if (m_CurrentHealth > m_MaxHealth) m_CurrentHealth = m_MaxHealth;

        if (m_CurrentHealth > 0) return;

        Death();
    }

    public virtual void Death()
    {
        if(ObjectMesh == null)
        {
            Debug.LogError("Custom Error - No object attached to Module_Health on " + gameObject.name);
            return;
        }

        if (gameObject.CompareTag("Enemy"))
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>() != null)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddPoints(m_EnemyBlackBoard.m_Points);
            else
                Debug.LogError("No GameController Found");
        }

        ObjectMesh.SetActive(false);
    }

    public void ResetObject()
    {
        ObjectMesh.SetActive(true);
        m_CurrentHealth = m_MaxHealth;
    }
}