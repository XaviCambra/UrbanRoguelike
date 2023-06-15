using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private MusicController m_Music;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<AudioManager>() != null)
            AudioManager.m_Instance.SetMusic(m_Music);
    }

    public void SetActiveMusic()
    {
        if (FindObjectOfType<AudioManager>() != null)
            AudioManager.m_Instance.SetMusic(m_Music);
    }
}
