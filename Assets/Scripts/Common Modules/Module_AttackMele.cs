using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public GameObject m_EnemyFist;
    float m_Damage;
    //Module_Animation m_Animation;
    public Animator m_animator;

    BoxCollider m_FistCollider;

    public void HitOnDirection(float l_Damage)
    {
        m_Damage = l_Damage;

        /*if (m_Animation == null) return;
        m_Animation.PlayAnimation("MeleAttack");*/

        if (m_animator == null) return;
        m_animator.SetTrigger("MeleAttack");

    }

    public void ActivateCollisionDetection()
    {
        m_FistCollider = GameObject.FindGameObjectWithTag("EnemyFist").GetComponent<BoxCollider>();

        m_FistCollider.enabled = true;

        //m_EnemyFist.SetActive(true);
    }

    public void DeactivateCollisionDetection()
    {
        m_FistCollider = GameObject.FindGameObjectWithTag("EnemyFist").GetComponent<BoxCollider>();

        m_FistCollider.enabled = false;

        //m_EnemyFist.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Module_Health objectHealth = other.GetComponent<Module_Health>();
            //if (objectHealth == null) return;
            objectHealth.TakeDamage(m_Damage);
        }
    }
}
