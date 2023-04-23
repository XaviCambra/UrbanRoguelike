using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : BaseItem
{
    [SerializeField] private float m_LifeSpan;
    [SerializeField] private float m_CurrentTime;

    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_ExplosionForce;
    [SerializeField] private float m_Damage;

    //private GameObject m_Explosion;
    

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        
    }

    private void Update()
    {
        m_CurrentTime += Time.deltaTime;

        if (m_CurrentTime >= m_LifeSpan)
        {
            Debug.Log("Llamada a explosion");
            Explode();
        }
    }

    private void Explode()
    {
        //Instantiate(m_Explosion, transform.position, transform.rotation);

        Collider[] l_colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        if (l_colliders != null)
        {
            foreach (Collider l_nearbyObject in l_colliders)
            {

                Rigidbody l_rb = l_nearbyObject.GetComponent<Rigidbody>();
                Module_Health l_health = l_nearbyObject.GetComponent<Module_Health>();

                if (l_rb != null && l_health != null)
                {
                    l_health.TakeDamage(m_Damage);
                    l_rb.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
                }
            }
        }

        Debug.Log("Explosion");
        Destroy(gameObject);
    }
}
