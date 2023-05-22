using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedEnemy : FSM_EnemyBase
{
    Module_AttackRanged m_AttackRanged;
    Module_Crouch m_Crouch;
    GameObject m_PlayerHitpoint;

    //EnemyBase_BLACKBOARD m_BlackBoard;

    public GameObject m_Player;


    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private float m_GrenadeForce;

    void Start()
    {
        m_Blackboard = GetComponent<EnemyBase_BLACKBOARD>();
        m_AttackRanged = GetComponent<Module_AttackRanged>();
        m_Crouch = GetComponent<Module_Crouch>();
        m_PlayerHitpoint = GameObject.FindGameObjectWithTag("PlayerHitpoint");

        m_Player = GameObject.FindGameObjectWithTag("Player");
        
        m_Blackboard.m_CanAttack = true;
    }

    protected override void Update()
    {
        base.Update();

        m_Blackboard.m_AttackPoint.transform.LookAt(m_PlayerHitpoint.transform);
    }

    public override void StateIdle()
    {
        base.StateIdle();
        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_DetectionRadius)
            SetStateAttack();
    }

    protected override void SetStateMovement()
    {
        base.SetStateMovement();
        Vector3 l_LookAtPlayer = m_Player.transform.position;
        l_LookAtPlayer.y = transform.position.y;
        transform.LookAt(l_LookAtPlayer);
    }

    protected override void SetStateAttack()
    {
        base.SetStateAttack();
        if (m_Blackboard.m_CanAttack == false) return;

        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_AttackDistance)
        {
            m_AttackRanged.ShootOnDirection(m_Blackboard.m_AttackPoint.position, m_Blackboard.m_AttackPoint.transform.rotation, m_Blackboard.m_AttackSpeed, m_Blackboard.m_Damage, "Enemy");
            
            m_Blackboard.m_CanAttack = false;
            StartCoroutine(CrouchIn());
        }

        if (Vector3.Distance(m_Player.transform.position, transform.position) < m_Blackboard.m_GrenadeDistance)
        {
            GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Blackboard.m_AttackPoint.transform.position, m_Blackboard.m_AttackPoint.transform.rotation);
            Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
            l_rb.AddForce(m_Blackboard.m_AttackPoint.transform.forward * m_GrenadeForce, ForceMode.VelocityChange);
            l_grenade.SetActive(true);

            m_Blackboard.m_CanAttack = false;
            StartCoroutine(CrouchIn());
        }
    }

    private IEnumerator CrouchIn()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Crouch");
        m_Crouch.AlternateCrouching(false);
        StartCoroutine(RechargeAttack());
    }
    private IEnumerator CrouchOut()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Crouch Out");
        m_Crouch.AlternateCrouching(true);
        m_Blackboard.m_CanAttack = true;
    }

    protected IEnumerator RechargeAttack()
    {
        float l_RechargeAttack = m_Blackboard.m_AttackCooldown + Random.Range(-0.75f, 0.75f);
        yield return new WaitForSeconds(l_RechargeAttack);
        StartCoroutine(CrouchOut());
    }

}
