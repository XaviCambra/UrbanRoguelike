using System.Collections;
using UnityEngine;

public class Player_BLACKBOARD : MonoBehaviour
{
    [SerializeField] private const float m_BASEMovementSpeed = 6.0f;
    [SerializeField] private const float m_BASECrouchingSpeed = 4.0f;

    [SerializeField] private const float m_BASEShootingDamage = 10.0f;
    [SerializeField] private const float m_BASEReloadSpeed = 3.0f;
    [SerializeField] private const float m_BASEBulletSpeed = 40.0f;
    [SerializeField] private const float m_BASEDashDistance = 1.5f;
    [SerializeField] private const float m_BASEDashSpeed = 8.0f;
    [SerializeField] private const int m_BASEMaxOverHeat = 5;

    [Header("Is Active")]
    public bool m_CanInteract = true;

    [Header("Movement")]
    public bool m_CanMove = true;
    public bool m_Crouching = false;
    public float m_MovementSpeed;
    public float m_CrouchingSpeed;
    public float m_Impulse;
    public float m_ImpulseSpeed;

    [Header("Shoot")]
    public float m_ShootingDamage;
    public float m_BulletSpeed;
    public float m_ReloadSpeed;
    public float m_MaxOverHeat;
    public float m_OverHeatCancelDuration;
    public Transform m_ShootPoint;
    public int m_CurrentShots;
    public bool m_CanOverheat = true;

    [Header("Dash")]
    public float m_DashDistance;
    public float m_DashSpeed;
    public int m_DashCount = 0;
    public int m_DashMaxCount = 2;
    public float m_DashCooldown = 3;

    [Header("Health")]
    public float m_InmortalityDuration;

    [Header("Items")]
    public BaseItem m_Item;
    public PowerUp_Base m_PowerUp;
    public bool m_HasGrenade;

    private void Start()
    {
        GameObject m_GameController = GameObject.FindGameObjectWithTag("GameController");
        if(m_GameController != null)
            m_GameController.GetComponent<GameController>().UsePermanentPowerUp();
    }

    public void ResetAllStats()
    {
        m_MovementSpeed = m_BASEMovementSpeed;
        m_CrouchingSpeed = m_BASECrouchingSpeed;
        m_ShootingDamage = m_BASEShootingDamage;
        m_ReloadSpeed = m_BASEReloadSpeed;
        m_BulletSpeed = m_BASEBulletSpeed;
        m_MaxOverHeat = m_BASEMaxOverHeat;

        m_HasGrenade = false;
    }

    public void OverHeat()
    {
        if (m_CanOverheat)
        {
            m_CurrentShots = (int)Mathf.Clamp(m_CurrentShots + 1, 0, m_MaxOverHeat);
            StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(m_ReloadSpeed);
        m_CurrentShots--;
    }

    public bool CanShoot()
    {
        return m_CurrentShots < m_MaxOverHeat; 
    }

    public void TEST_GetBuff()
    {
        m_ShootingDamage += 10;
        m_ReloadSpeed -= 0.5f;
        m_MaxOverHeat += 1;
        m_DashCooldown -= 0.5f;
        m_DashMaxCount++;
    }
}
