using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FModEvents : MonoBehaviour
{
    [field: Header("Abilities")]


    [field: Header("SFX - UI")]
    [field: SerializeField] public EventReference m_ClickMenuSound { get; private set; }
    [field: SerializeField] public EventReference m_UpgradeMenuSound { get; private set; }
    [field: SerializeField] public EventReference m_BuyItemSound { get; private set; }
    [field: SerializeField] public EventReference m_OnMouseOverSound { get; private set; }
    [field: SerializeField] public EventReference m_PauseMenuExitSound { get; private set; }
    [field: Header("SFX - Effects")]
    [field: SerializeField] public EventReference m_HealSound { get; private set; }
    [field: SerializeField] public EventReference m_ShieldAppearSound { get; private set; }
    [field: SerializeField] public EventReference m_ShieldDisappearSound { get; private set; }
    [field: SerializeField] public EventReference m_KillderModeSound { get; private set; }
    [field: Header("SFX - Player")]
    [field: Header("SFX - Enemies")]
    [field: Header("SFX - Modules")]
    [field: SerializeField] public EventReference m_DashSound { get; private set; }


    public static FModEvents m_Instance { get; private set; }

    private void Awake()
    {
        if (m_Instance != null)
        {
            Debug.LogError("More than one FModEvents");
            Destroy(gameObject);
        }
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
