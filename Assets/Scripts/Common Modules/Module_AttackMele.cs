using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public GameObject m_EnemyFist;
    float m_Damage;
    Module_Animation m_Animation;

    public Module_TriggerDamage m_FistCollider;

    private void Start()
    {
        m_Animation = GetComponent<Module_Animation>();
    }

    public void HitOnDirection(float l_Damage)
    {
        m_Damage = l_Damage;
        

        if (m_Animation == null)
        {
            Debug.LogWarning("No Module Animation found");
            return;
        }
        if (m_FistCollider == null)
        {
            Debug.LogWarning("No FistCollider detected");
            return;
        }
        m_FistCollider.m_Damage = l_Damage;
        m_Animation.PlayAnimation("MeleAttack");


    }

}
