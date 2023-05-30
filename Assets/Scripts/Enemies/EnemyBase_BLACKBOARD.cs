using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_BLACKBOARD : MonoBehaviour
{
    [Header("Common")]
    [Header("Movement")]
    public float m_WalkSpeed;
    public float m_RunSpeed;
    [Header("Distances")]
    public float m_DetectionRadius;
    [Header("Other variables")]
    public bool m_CanAttack;
    public bool m_IsActive = true;
    [Header("Objects")]
    public Transform m_AttackPoint;
    [Header("Score Points")]
    public int m_Points;
    [Header("Mele Enemy")]
    [Header("Dash")]
    public float m_DashDistance;
    public float m_DashSpeed;
    public float m_DashChargedDistance;
    [Header("Distances")]
    public float m_FollowDistance;
    public float m_AttackDistance;
    [Header("Ranged Enemy")]
    [Header("Crouching")]
    public bool m_Crouching;
    public float m_CrouchInTime;
    public float m_CrouchOutTime;
    [Header("Bullet")]
    public float m_Damage;
    public float m_AttackSpeed;
    public float m_AttackCooldown;
    [Header("Grenade")]
    public bool m_GrenadeLoaded = true;
    public float m_GrenadeDistance;
    public float m_GrenadeCooldown;
    public float m_GrenadeForce;
}
