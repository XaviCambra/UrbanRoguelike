using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class FingerprintTrigger : BaseItem
{
    bool m_IsActive;
    public bool m_ItemEnabled;
    Coroutine m_Coroutine;
    InputController m_InputController;

    public List<FingerprintTrigger> m_Triggers;
    public List<CloseDoor> m_Barriers;

    private void Start()
    {
        m_InputController = GetComponent<InputController>();
        m_ItemEnabled = true;
    }

    private void Update()
    {
        if (!m_ItemEnabled)
            return;

        if (!m_IsActive)
            return;

        Debug.Log("Is active");
        if (Input.GetKeyDown(m_InputController.m_UseItemKey))
        {
            Debug.Log("Button pressed");
            m_ItemEnabled = false;
            bool l_CanActivate = false;
            foreach(FingerprintTrigger trigger in m_Triggers)
            {
                if (!trigger.m_ItemEnabled)
                    l_CanActivate = true;
            }

            if (!l_CanActivate)
            {
                foreach (CloseDoor l_Barrier in m_Barriers)
                {
                    l_Barrier.ApplyEffectItem();
                }
            }
        }
    }


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
