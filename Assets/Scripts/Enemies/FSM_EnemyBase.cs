using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    protected EnemyBase_BLACKBOARD m_Blackboard;
    public bool m_IsKnockback;
    public bool m_HasToKnockback;
    public float Value;

    protected virtual void Update()
    {
        if (m_HasToKnockback)
        {
            if (m_IsKnockback) return;
            GetKnockback(-Vector3.forward, Value);
            return;
        }
        EnemyMovement();
        EnemyAttack();
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {

    }

    public void GetKnockback(Vector3 l_PushDirection, float l_PushForce)
    {
        m_IsKnockback = true;
        StartCoroutine(Push(l_PushDirection, l_PushForce));
    }

    public IEnumerator Push(Vector3 l_PushDirection, float l_PushForce)
    {
        Vector3 l_Initialposition = transform.position;
        float l_Time = 0;
        float l_MaxTime = 25;
        while(l_Time < l_MaxTime)
        {
            float l_TimeSpent = l_Time / l_MaxTime;
            Vector3 l_Direction = Vector3.Lerp(l_Initialposition, l_Initialposition + l_PushDirection * l_PushForce, l_TimeSpent);
            l_Direction.y = Mathf.Sin(l_TimeSpent);
            transform.position = l_Direction;
            Debug.Log(l_Time);
            l_Time = (l_Time + 1) % (l_MaxTime + 1);
            yield return null;
        }

        m_HasToKnockback = false;
        m_IsKnockback = false;
    }
}
