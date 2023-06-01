using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : BaseItem
{
    bool m_DoorOppened = false;
    [SerializeField] float m_ClosePosition;
    [SerializeField] float m_OpenPosition;
    [SerializeField] float m_AnimationDuration;

    [SerializeField] EnemyBase_BLACKBOARD m_Boss;

    private void Start()
    {
        StartCoroutine(OpenDoorAnimation());
    }

    public override void ApplyEffectItem()
    {
        /*  Write your own code below */
        if(m_DoorOppened)
            StartCoroutine(CloseDoorAnimation());
        else
            StartCoroutine(OpenDoorAnimation());

        if (m_Boss != null)
            StartCoroutine(SetActiveEnemy());
    }

    private IEnumerator OpenDoorAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        float l_TimeRate = 1f / m_AnimationDuration;
        float t = 0.0f;
        Vector3 l_ClosePosition = transform.position;
        l_ClosePosition.y = m_ClosePosition;
        Vector3 l_OpenPosition = transform.position;
        l_OpenPosition.y = m_OpenPosition;
        while (transform.position != l_OpenPosition)
        {
            t += Time.deltaTime * l_TimeRate;
            transform.position = Vector3.Lerp(l_ClosePosition, l_OpenPosition, t);
            yield return null;
        }
        m_DoorOppened = true;
    }

    private IEnumerator SetActiveEnemy()
    {
        yield return new WaitForSeconds(3);
        m_Boss.m_IsActive = true;
    }

    private IEnumerator CloseDoorAnimation()
    {
        float l_TimeRate = 1f / m_AnimationDuration;
        float t = 0.0f;
        Vector3 l_ClosePosition = transform.position;
        l_ClosePosition.y = m_ClosePosition;
        Vector3 l_OpenPosition = transform.position;
        l_OpenPosition.y = m_OpenPosition;
        while (transform.position != l_ClosePosition)
        {
            t += Time.deltaTime * l_TimeRate;
            transform.position = Vector3.Lerp(l_OpenPosition, l_ClosePosition, t);
            yield return null;
        }
        m_DoorOppened = false;
    }
}
