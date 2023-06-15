using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_TriggerDamage : MonoBehaviour
{
    public float m_Damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        Module_Health objectHealth = other.GetComponent<Module_Health>();
        if (objectHealth == null) return;
        objectHealth.TakeDamage(m_Damage);
        gameObject.SetActive(false);
    }
}
