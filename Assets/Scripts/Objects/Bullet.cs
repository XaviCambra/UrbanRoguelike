using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Damage;
    public float m_Speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");

        if (collision.collider.GetComponent<Module_Health>() != null)
        {
            collision.collider.GetComponent<Module_Health>().TakeDamage(m_Damage);
        }

        Destroy(gameObject);
    }
}
