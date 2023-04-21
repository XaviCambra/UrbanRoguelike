using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Animation : MonoBehaviour
{
    public Animator m_Animator;

    public float PlayAnimation(string l_ParameterName, int l_Value)
    {
        m_Animator.SetInteger(l_ParameterName, l_Value);
        float l_AnimationDuration = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
        return l_AnimationDuration;
    }

    public float PlayAnimation(string l_ParameterName, float l_Value)
    {
        m_Animator.SetFloat(l_ParameterName, l_Value);
        float l_AnimationDuration = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
        return l_AnimationDuration;
    }

    public float PlayAnimation(string l_ParameterName, bool l_Value)
    {
        m_Animator.SetBool(l_ParameterName, l_Value);
        float l_AnimationDuration = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
        return l_AnimationDuration;
    }

    public float PlayAnimation(string l_ParameterName)
    {
        m_Animator.SetTrigger(l_ParameterName);
        float l_AnimationDuration = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
        return l_AnimationDuration;
    }
}
