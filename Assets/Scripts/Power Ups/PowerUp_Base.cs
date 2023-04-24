using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Base : MonoBehaviour
{
    protected Player_BLACKBOARD m_BlackBoard;

    public virtual void ApplyPowerUp
        ()
    {
        m_BlackBoard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        m_BlackBoard.m_PowerUp = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_BlackBoard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        if (m_BlackBoard == null) return;

        if (m_BlackBoard.m_PowerUp != null) return;

        else
        {
            m_BlackBoard.GetComponent<Player_BLACKBOARD>().m_PowerUp = this;

            gameObject.SetActive(false);
        }

    }
}
