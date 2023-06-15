using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public GameObject m_EnemyFist;
    
    public Module_TriggerDamage m_FistCollider;

    public void HitOnDirection(float l_Damage)
    {        
        if (m_FistCollider == null)
        {
            Debug.LogWarning("No FistCollider detected");
            return;
        }
        m_FistCollider.m_Damage = l_Damage;
        m_FistCollider.gameObject.SetActive(true);
    }

}
