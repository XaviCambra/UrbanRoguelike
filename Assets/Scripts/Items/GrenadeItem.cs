using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : MonoBehaviour
{
    [SerializeField] private float m_LifeSpan;
    [SerializeField] private float m_CurrentTime;

    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_Damage;

    [SerializeField] private float m_MaxDistance;
    [SerializeField] private float m_MaxBounds;
    [SerializeField] private float m_CurrentBound;
    private bool m_UsedItem;


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
        /*  Write your own code below */
        m_UsedItem = true;
        gameObject.SetActive(true);
        

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

    //private void Update()
    //{
    //    if (m_UsedItem)
    //    {
    //        transform.Translate(Vector3.forward * m_MoveSpeed * Time.deltaTime);
    //    }
    //}
}
