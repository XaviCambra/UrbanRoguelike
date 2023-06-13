using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem m_ParticleSystem;
    GameObject m_ParticleObject;

    public void PlayParticles(Vector3 l_Forward)
    {
        m_ParticleObject = m_ParticleSystem.gameObject;
        m_ParticleObject.transform.forward = l_Forward;
        m_ParticleSystem.Play();
    }
}
