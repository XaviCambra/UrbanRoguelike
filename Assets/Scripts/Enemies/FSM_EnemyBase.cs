using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_EnemyBase : MonoBehaviour
{
    protected EnemyBase_BLACKBOARD m_Blackboard;
    private bool m_IsActive = true;

    protected enum EnemyStates
    {
        Idle,
        Movement,
        Attack
    }

    [SerializeField] protected EnemyStates m_State = EnemyStates.Idle;

    protected virtual void Update()
    {
        if (m_IsActive == false) return;

        switch (m_State)
        {
            case EnemyStates.Idle:
                StateIdle();
                break;
            case EnemyStates.Movement:
                StateMovement();
                break;
            case EnemyStates.Attack:
                StateAttack();
                break;
            default:
                SetStateIdle();
                break;
        }
    }

    protected virtual void SetStateIdle() { m_State = EnemyStates.Idle; }
    public virtual void StateIdle() { }
    protected virtual void SetStateMovement() { m_State = EnemyStates.Movement; }
    public virtual void StateMovement() { }
    protected virtual void SetStateAttack() { m_State = EnemyStates.Attack; }
    public virtual void StateAttack() { }
    protected virtual void SetStateWait(float l_Duration) { StartCoroutine(StateWait(l_Duration)); }
    public virtual IEnumerator StateWait(float l_Duration)
    {
        yield return new WaitForSeconds(l_Duration);
        m_State = EnemyStates.Idle;
    }

    private void SetInnactiveObject()
    {
        m_IsActive = false;
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().m_PlayerIsDead += SetInnactiveObject;
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().m_PlayerIsDead -= SetInnactiveObject;
    }
}
