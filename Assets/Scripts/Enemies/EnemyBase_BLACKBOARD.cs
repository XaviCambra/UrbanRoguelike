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

    //Distances
    public float m_DetectionRadius;
    public float m_FollowDistance;
    public float m_AttackDistance;
    public float m_DashDistance;
    public float m_DashChargedDistance;

    //Variables
    public bool m_CanAttack;

    //Objects
    public Transform m_AttackPoint;

    //Points
    public int m_Points;
}
