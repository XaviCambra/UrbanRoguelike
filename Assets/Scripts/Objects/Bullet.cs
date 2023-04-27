using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Damage;
    public float m_Speed;
    public string m_TagToKill;

    private void Update()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Module_Health m_Health = collision.collider.GetComponent<Module_Health>();
        if (m_Health != null && collision.collider.tag.Equals(m_TagToKill))
        {
            m_Health.TakeDamage(m_Damage);
        }

        Destroy(gameObject);
    }
}
