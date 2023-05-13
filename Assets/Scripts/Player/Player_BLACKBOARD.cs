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
    [SerializeField] private const float m_BASEDashDistance = 1.5f;
    [SerializeField] private const float m_BASEDashSpeed = 8.0f;
    [SerializeField] private const int m_BASEMaxOverHeat = 5;

    [Header("Movement")]
    public float m_MovementSpeed;
    public float m_CrouchingSpeed;

    [Header("Shoot")]
    public bool m_CanAttack;
    public float m_ShootingDamage;
    public float m_BulletSpeed;
    public float m_ReloadSpeed;
    public float m_MaxOverHeat;
    public float m_OverHeatCancelDuration;
    public Transform m_ShootPoint;

    [Header("Dash")]
    public float m_DashDistance;
    public float m_DashSpeed;

    [Header("Health")]
    public float m_InmortalityDuration;

    [Header("Items")]
    public BaseItem m_Item;
    public PowerUp_Base m_PowerUp;


    private void Start()
    {
        GameController.UsePermanentPowerUp();
    }

    public void ResetAllStats()
    {
        m_MovementSpeed = m_BASEMovementSpeed;
        m_CrouchingSpeed = m_BASECrouchingSpeed;
        m_ShootingDamage = m_BASEShootingDamage;
        m_ReloadSpeed = m_BASEReloadSpeed;
        m_BulletSpeed = m_BASEBulletSpeed;
        m_MaxOverHeat = m_BASEMaxOverHeat;
    }
}
