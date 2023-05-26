using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GrenadeItem : MonoBehaviour
{
    [SerializeField] private float m_LifeSpan;
    [SerializeField] private float m_CurrentTime;
    [SerializeField] private float m_MoveSpeed;

    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_ExplosionForce;
    [SerializeField] private float m_Damage;

    [SerializeField] private InputController m_InputController;
    [SerializeField] private Player_BLACKBOARD m_PlayerBlackboard;
    [SerializeField] private GameObject m_PlayerBulletOrigin;

    private void Start()
    {
        m_InputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        m_PlayerBulletOrigin = GameObject.FindGameObjectWithTag("PlayerBulletOrigin");
    }

    public void UseGrenade(Transform l_AttackPoint, Quaternion l_InitialRotation, float l_GrenadeForce, bool l_HaveGravity)
    {
        GameObject l_grenade = Instantiate(gameObject, l_AttackPoint.position, l_InitialRotation);
        Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
        l_rb.AddForce(l_AttackPoint.forward * l_GrenadeForce, ForceMode.VelocityChange);
        l_rb.useGravity = l_HaveGravity;
        l_grenade.SetActive(true);
    }

    private void Update()
    {
        if (m_CurrentTime >= m_LifeSpan)
        {
            Explode();
            return;
        }
        
        m_CurrentTime += Time.deltaTime;

        if (Input.GetKeyUp(m_InputController.m_UseItemKey) && m_PlayerBlackboard.m_HasGrenade)
        {
            Rigidbody l_rb = gameObject.GetComponent<Rigidbody>();
            l_rb.useGravity = true;
            l_rb.AddForce(m_PlayerBulletOrigin.transform.forward * m_MoveSpeed, ForceMode.VelocityChange);

            gameObject.transform.SetParent(null);

            m_PlayerBlackboard.m_HasGrenade = false;
            Debug.Log("Granada lanzada");
        }
    }

    private void Explode()
    {
        Collider[] l_colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        if (l_colliders == null) return;

        foreach (Collider l_nearbyObject in l_colliders)
        {
            Module_Health l_health = l_nearbyObject.GetComponent<Module_Health>();

            if (l_health != null)
            {
                l_health.TakeDamage(m_Damage);
            }
        }
        Debug.Log("Granada explota");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(gameObject.transform.position, m_ExplosionRadius);
    }
}
