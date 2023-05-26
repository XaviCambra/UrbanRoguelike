using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_BLACKBOARD : MonoBehaviour
{
    //Movement
    public float m_WalkSpeed;
    public float m_RunSpeed;

    //Attack
    public float m_Damage;
    public float m_AttackSpeed;
    public float m_AttackCooldown;
    public float m_GrenadeCooldown;

    //Distances
    public float m_DetectionRadius;
    public float m_FollowDistance;
    public float m_AttackDistance;
    public float m_DashDistance;
    public float m_DashSpeed;
    public float m_DashChargedDistance;
    public float m_GrenadeDistance;

    //Variables
    public bool m_CanAttack;
    public bool m_Crouching;

    //Objects
    public Transform m_AttackPoint;

    //Points
    public int m_Points;
}
