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

        base.TakeDamage(l_Damage);
    }

    public override void Death()
    {
        base.Death();
        m_PlayerIsDead?.Invoke();
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }
}
