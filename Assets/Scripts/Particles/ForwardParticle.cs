using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardParticle : MonoBehaviour
{
    public GameObject m_ParticleObject;
    public bool m_CustomPosition;
    public bool m_Inverted;

    public void Play(Vector3 l_Position, Vector3 l_Forward)
    {
        if(!m_CustomPosition)
            m_ParticleObject.transform.position = l_Position;
        m_ParticleObject.transform.forward = l_Forward;
        ParticleSystem l_ParticleSystem = m_ParticleObject.GetComponent<ParticleSystem>();
        l_ParticleSystem.Play();
    }
}
