using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp_Base : ScriptableObject
{
    protected Player_BLACKBOARD m_BlackBoard;

    public string PowerUp_Name;
    public Sprite PowerUp_Image;
    [TextArea(3, 3, order = 1)]
    public string PowerUp_Description;

    public virtual void ApplyPowerUp()
    {
        m_BlackBoard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        if (m_BlackBoard == null) return;
        m_BlackBoard.m_PowerUp = null;
    }
}
