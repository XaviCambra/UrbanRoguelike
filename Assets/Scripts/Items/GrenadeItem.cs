using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : BaseItem
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_LifeSpan;
    [SerializeField] private float m_CurrentTime;
    private bool m_UsedItem;

    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_ExplosionForce;
    [SerializeField] private float m_Damage;

    //private GameObject m_Explosion;

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_UsedItem = true;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (m_UsedItem)
        {
            m_CurrentTime += Time.deltaTime;

            if (m_CurrentTime <= m_LifeSpan)
            {
                //m_CurrentTime = m_LifeSpan;
                transform.Translate(Vector3.forward * m_MoveSpeed * Time.deltaTime);
            }

            else
            {
                Explode();
            }

            
        }
    }

    private void Explode()
    {
        //Instantiate(m_Explosion, transform.position, transform.rotation);

        Collider[] l_colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        foreach(Collider l_nearbyObject in l_colliders)
        {
            Rigidbody l_rb = l_nearbyObject.GetComponent<Rigidbody>();

            if (l_rb != null)
            {
                l_rb.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            }
        }

        Destroy(gameObject);
    }
}
