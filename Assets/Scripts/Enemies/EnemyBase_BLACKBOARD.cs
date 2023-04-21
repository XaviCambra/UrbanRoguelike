using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_BLACKBOARD : MonoBehaviour
{
    public float m_MovementSpeed;
    public float m_Damage;

    public float m_CoverDetectionRadius;

    public bool m_CanAttack;
    public float m_AttackSpeed;
    public float m_AttackCooldown;

    public Transform m_AttackPoint;

    //public float m_MaxHP;
}
