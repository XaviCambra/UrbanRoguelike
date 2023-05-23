using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp_Base : ScriptableObject
{
    protected Player_BLACKBOARD m_BlackBoard;
    protected EnemyBase_BLACKBOARD m_EnemyBlackboard;
    protected Player_Health m_PlayerHP;

    public string m_PowerUp_Name;
    public Sprite m_PowerUp_Image;
    [TextArea(3, 3, order = 1)]
    public string m_PowerUp_Description;
    public int m_PowerUp_Price;

    public virtual void ApplyPowerUp()
    {
        m_BlackBoard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        if (m_BlackBoard == null) return;
        m_BlackBoard.m_PowerUp = null;
    }
}
