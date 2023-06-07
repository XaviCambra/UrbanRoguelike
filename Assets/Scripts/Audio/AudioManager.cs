using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager m_Instance { get; private set; }

    private void Awake()
    {
        if(m_Instance != null)
        {
            Debug.LogError("More than one Audio Manager");
        }
        m_Instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
