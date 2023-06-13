using System.Collections;
using System.Collections.Generic;
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
            AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.m_GrenadeThrow, transform.position);

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

        AudioManager.m_Instance.PlayOneShot(FModEvents.m_Instance.M_GrenadeExplode, transform.position);


        if (l_colliders == null) return;

        foreach (Collider l_nearbyObject in l_colliders)
        {
            Module_Health l_health = l_nearbyObject.GetComponent<Module_Health>();

            if (l_health != null)
            {
                l_health.TakeDamage(m_Damage);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(gameObject.transform.position, m_ExplosionRadius);
    }
}
