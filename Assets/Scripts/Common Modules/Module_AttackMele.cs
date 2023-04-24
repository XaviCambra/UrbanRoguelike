using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public GameObject m_HitPoint;
    float m_Damage;
    Module_Animation m_Animation;

    public void HitOnDirection(float l_Damage)
    {
        m_Damage = l_Damage;

        if (m_Animation == null) return;
        m_Animation.PlayAnimation("MeleAttack");
    }

    public void ActivateCollisionDetection()
    {
        m_HitPoint.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Module_Health objectHealth = other.GetComponent<Module_Health>();
        if (objectHealth == null) return;
        objectHealth.TakeDamage(m_Damage);
    }
}
