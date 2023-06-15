using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp_MaxHP", menuName = "Power Up/PowerUp_MaxHP", order = 1)]
public class PowerUp_MaxHP : PowerUp_Base
{
	public float m_HPIncrease;
    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();

        m_PlayerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        /*  Write your own code below */
        m_PlayerHP.m_MaxHealth += Mathf.Abs(m_HPIncrease);
        m_PlayerHP.m_CurrentHealth += Mathf.Abs(m_HPIncrease);
    }
}
