using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : BaseItem
{
    [SerializeField] Vector3 m_ClosePosition;
    [SerializeField] Vector3 m_OpenPosition;
    [SerializeField] float m_AnimationDuration;

    private void Start()
    {
        transform.position = m_OpenPosition;
    }

    public override void ApplyEffectItem()
    {
        /*  Write your own code below */
        StartCoroutine(CloseDoorAnimation());
    }
    
    private IEnumerator CloseDoorAnimation()
    {
        float l_TimeRate = 1f / m_AnimationDuration;
        float t = 0.0f;
        while (transform.position != m_ClosePosition)
        {
            t += Time.deltaTime * l_TimeRate;
            transform.position = Vector3.Lerp(m_OpenPosition, m_ClosePosition, t);
            yield return null;
        }
    }
}
