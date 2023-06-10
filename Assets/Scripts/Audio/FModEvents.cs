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
    [field: SerializeField] public EventReference m_PauseMenuSound { get; private set; }
    [field: SerializeField] public EventReference m_PauseMenuExitSound { get; private set; }
    [field: SerializeField] public EventReference m_ActivateItem { get; private set; }
    [field: SerializeField] public EventReference m_CloseStore { get; private set; }



    [field: Header("SFX - Effects")]
    [field: SerializeField] public EventReference m_HealSound { get; private set; }
    [field: SerializeField] public EventReference m_ShieldAppearSound { get; private set; }
    [field: SerializeField] public EventReference m_ShieldDisappearSound { get; private set; }
    [field: SerializeField] public EventReference m_KillerModeSound { get; private set; }
    
    
    
    [field: Header("SFX - Player")]
    [field: SerializeField] public EventReference m_PlayerReload { get; private set; }
    [field: SerializeField] public EventReference m_PlayerDie { get; private set; }
    [field: SerializeField] public EventReference m_PlayerStep1 { get; private set; }
    [field: SerializeField] public EventReference m_PlayerStep2 { get; private set; }
    [field: SerializeField] public EventReference m_PlayerShoot { get; private set; }
    [field: SerializeField] public EventReference m_PlayerHit { get; private set; }
    [field: SerializeField] public EventReference m_PlayerCantShoot { get; private set; }



    [field: Header("SFX - Enemies")]
    [field: SerializeField] public EventReference m_MeleeAttack1 { get; private set; }
    [field: SerializeField] public EventReference m_MeleeAttack2 { get; private set; }
    [field: SerializeField] public EventReference m_MeleeDie { get; private set; }
    [field: SerializeField] public EventReference m_RangedShoot { get; private set; }



    [field: Header("SFX - Modules")]
    [field: SerializeField] public EventReference M_GrenadeExplode { get; private set; }
    [field: SerializeField] public EventReference m_GrenadeThrow { get; private set; }
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
