using System.Collections;
using UnityEngine;

public class FingerprintTrigger : BaseItem
{
    bool m_IsActive;
    Coroutine m_Coroutine;


    public void SetActive()
    {
        if (m_Coroutine == null)
        {
            m_Coroutine = StartCoroutine(SetActiveSeconds());
            return;
        }

        StopCoroutine(m_Coroutine);
        m_Coroutine = StartCoroutine(SetActiveSeconds());
    }

    private IEnumerator SetActiveSeconds()
    {
        m_IsActive = true;
        yield return new WaitForSeconds(1);
        m_IsActive = false;
    }
}
