using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    public static AudioManager m_Instance { get; private set; }
    public static EventInstance m_MusicEventInstance { get; private set; }

    private void Awake()
    {
        if(m_Instance != null)
        {
            Debug.LogError("More than one Audio Manager");
            Destroy(gameObject);
        }
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeMusic(FModEvents.m_Instance.m_LvlMusic);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void InitializeMusic(EventReference MusicEventReference)
    {
        m_MusicEventInstance = CreateInstance(MusicEventReference);
        m_MusicEventInstance.start();
    }

    public void SetMusic(MusicController music)
    {
        m_MusicEventInstance.setParameterByName("music", (float) music);
    }
}
