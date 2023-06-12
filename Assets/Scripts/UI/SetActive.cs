using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject m_ObjectToSetActive;

    public void SetObjectActive()
    {
        m_ObjectToSetActive.SetActive(true);
    }

    public void SetObjectInnactive()
    {
        m_ObjectToSetActive.SetActive(false);
    }
}
