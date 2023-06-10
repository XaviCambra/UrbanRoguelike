using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : Module_Health
{
    public delegate void PlayerIsDead();
    public PlayerIsDead m_PlayerIsDead;

    public bool m_CanLooseHealth;

    public override void TakeDamage(float l_Damage)
    {
        if (!m_CanLooseHealth)
            return;

        AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerHit, transform.position);
        base.TakeDamage(l_Damage);
    }

    public override void Death()
    {
        AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_PlayerDie, transform.position);
        base.Death();
        m_PlayerIsDead?.Invoke();
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }
}
