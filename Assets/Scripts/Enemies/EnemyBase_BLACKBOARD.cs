using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_BLACKBOARD : MonoBehaviour
{
    [Header("Movement")]
    public float m_WalkSpeed;
    public float m_RunSpeed;

    [Header("Dash")]
    public float m_DashDistance;
    public float m_DashSpeed;
    public float m_DashChargedDistance;

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

    [Header("Distances")]
    public float m_DetectionRadius;
    public float m_FollowDistance;
    public float m_AttackDistance;

    [Header("Other variables")]
    public bool m_CanAttack;

    [Header("Objects")]
    public Transform m_AttackPoint;

    [Header("Score Points")]
    public int m_Points;
}
