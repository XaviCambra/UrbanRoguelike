using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : MonoBehaviour
{
    [SerializeField] private float m_LifeSpan;
    [SerializeField] private float m_CurrentTime;

    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_ExplosionForce;
    [SerializeField] private float m_Damage;


    private void Update()
    {
        if (m_CurrentTime >= m_LifeSpan)
        {
            Explode();
            return;
        }
        
        m_CurrentTime += Time.deltaTime;
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

        Destroy(gameObject);
    }
}
