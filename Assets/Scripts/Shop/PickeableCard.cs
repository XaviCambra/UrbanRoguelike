using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickeableCard : MonoBehaviour
{
    public PowerUpCard m_ActiveCard;

    public void SetActiveCard()
    {
        m_ActiveCard.SetPower(GetComponent<PowerUpCard>().m_PowerUp);
    }
}
