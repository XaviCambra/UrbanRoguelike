using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public GameObject m_EnemyFist;
    float m_Damage;
    

    public Module_TriggerDamage m_FistCollider;

    private void Start()
    {
        
    }

    public void HitOnDirection(float l_Damage)
    {
        m_Damage = l_Damage;
        
        if (m_FistCollider == null)
        {
            Debug.LogWarning("No FistCollider detected");
            return;
        }
        m_FistCollider.m_Damage = l_Damage;
        
    }

}
