using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BLACKBOARD : MonoBehaviour
{
    [SerializeField] private const float m_BASEMovementSpeed = 6.0f;
    [SerializeField] private const float m_BASECrouchingSpeed = 4.0f;

    [SerializeField] private const float m_BASEShootingDamage = 10.0f;
    [SerializeField] private const float m_BASEReloadSpeed = 3.0f;
    [SerializeField] private const float m_BASEBulletSpeed = 10.0f;
    [SerializeField] private const float m_BASEBulletCritChange = 10.0f;
    [SerializeField] private const float m_BASEBulletCritDamage = 150.0f;
    [SerializeField] private const int m_BASEMaxOverHeat = 5;
    [SerializeField] private const int m_BaseOverHeatWindow = 3;

    [Header("Variable Movement")]
    public float m_MovementSpeed;
    public float m_CrouchingSpeed;


    [Header("Variable Shoot")]
    public float m_ShootingDamage;
    public float m_BulletSpeed;
    public float m_ReloadSpeed;
    public float m_MaxOverHeat;
    public float m_OverHeatWindow;
    public float m_BulletCritChange;
    public float m_BulletCritDamage;
    public Transform m_ShootPoint;
    public bool m_CanAttack;

    public float m_OverHeatCancelDuration;

    public BaseItem m_Item;
    public PowerUp_Base m_PowerUp;


    public bool m_HasKey;

    public void ResetAllStats()
    {
        m_MovementSpeed = m_BASEMovementSpeed;
        m_CrouchingSpeed = m_BASECrouchingSpeed;
        m_ShootingDamage = m_BASEShootingDamage;
        m_ReloadSpeed = m_BASEReloadSpeed;
        m_BulletSpeed = m_BASEBulletSpeed;
        m_BulletCritChange = m_BASEBulletCritChange;
        m_BulletCritDamage = m_BASEBulletCritDamage;
        m_MaxOverHeat = m_BASEMaxOverHeat;
        m_OverHeatWindow = m_BaseOverHeatWindow;
    }
}
