using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Health : MonoBehaviour
{
    [Header("Statistics")]
    public float m_MaxHealth;
    private float m_Health;

    [Header("Object Model")]
    public GameObject ObjectMesh;

    public delegate void PlayerIsDead(bool isDead);
    public PlayerIsDead m_PlayerIsDead;

    private void Start()
    {
        m_Health = m_MaxHealth;
    }

    public void TakeDamage(float l_Damage)
    {
        Debug.Log(gameObject.name + " received damage: " + l_Damage);
        Debug.Log(gameObject.name +  " has health: " + m_Health);
        m_Health -= l_Damage;

        Death();
    }

    public void Death()
    {
        if (m_Health > 0) return;

        if(ObjectMesh == null)
        {
            Debug.LogError("Custom Error - No object attached to Module_Health on " + gameObject.name);
            return;
        }

        Debug.Log(gameObject.name + " is dead");
        m_PlayerIsDead?.Invoke(true);
        ObjectMesh.SetActive(false);
    }

    public void ResetObject()
    {
        ObjectMesh.SetActive(true);
        m_PlayerIsDead?.Invoke(false);
        m_Health = m_MaxHealth;
    }
}
