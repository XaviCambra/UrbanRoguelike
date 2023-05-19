using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Damage;
    public float m_Speed;
    public string m_TagToIgnore;

    public Vector3 m_Direction;

    public int m_BouncingNumber;

    private void Start()
    {
        m_Direction = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(m_Direction * m_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals(m_TagToIgnore))
            return;

        Module_Health m_Health = collision.collider.GetComponent<Module_Health>();
        if (m_Health != null)
        {
            m_Health.TakeDamage(m_Damage);
            Destroy(gameObject);
            return;
        }

        if(m_BouncingNumber > 0)
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 position = contact.normal;
            m_Direction = Vector3.Reflect(m_Direction, position);
            m_BouncingNumber--;
        }
        else
            Destroy(gameObject);
    }
}
