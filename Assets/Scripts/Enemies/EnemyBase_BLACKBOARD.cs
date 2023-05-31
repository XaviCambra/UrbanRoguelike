using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_BLACKBOARD : MonoBehaviour
{
    [Header("Movement")]
    public float m_WalkSpeed;
    public float m_RunSpeed;

    [Header("Distances")]
    public float m_DetectionRadius;

    [Header("Other variables")]
    public bool m_CanAttack;
    public bool m_IsActive = true;

    [Header("Objects")]
    public Transform m_RotationAttackPoint;
    public Transform m_AttackPoint;

    [Header("Score Points")]
    public int m_Points;

    [Header("Dash")]
    public float m_DashDistance;
    public float m_DashSpeed;
    public float m_DashChargedDistance;

    [Header("Distances")]
    public float m_FollowDistance;
    public float m_AttackDistance;

    [Header("Crouching")]
    public bool m_Crouching;
    public float m_CrouchInTime;
    public float m_CrouchOutTime;

    [Header("Bullet")]
    public bool m_BulletLoaded = true;
    public float m_BulletDamage;
    public float m_AttackSpeed;
    public float m_BulletCooldown;
    public float m_BulletAttackDuration;
    public float m_BulletAngle;

    [Header("Grenade")]
    public bool m_GrenadeLoaded = true;
    public float m_GrenadeDistance;
    public float m_GrenadeCooldown;
    public float m_GrenadeForce;
    public float m_GrenadeAttackDuration;

    [Header("Misile")]
    public bool m_MisileLoaded = true;
    public float m_MisileDamage;
    public float m_MisileCooldown;
    public float m_MisileAttackDuration;
}
