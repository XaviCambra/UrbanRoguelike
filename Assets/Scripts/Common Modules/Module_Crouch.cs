using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Crouch : MonoBehaviour
{
    private CharacterController m_CharacterController;
    private Animator m_Animator;

    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    public bool Crouching(bool l_Crocuching, float l_TransitionDuration)
    {
        if (l_Crocuching) Crouching_Out(l_TransitionDuration);
        else Crouching_In(l_TransitionDuration);
        return !l_Crocuching;
    }

    void Crouching_In(float l_TransitionDuration)
    {
        //m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(0, m_CharacterController.center/2, m_CharacterController.height/2));
        if(m_Animator != null)
            m_Animator.SetTrigger("CrouchIn");
    }

    void Crouching_Out(float l_TransitionDuration)
    {
        //float duration = m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(1, m_CharacterController.center*2, m_CharacterController.height*2));
        if (m_Animator != null)
            m_Animator.SetTrigger("CrouchOut");
    }

    IEnumerator ModifyCharacterCollider(float transitionDuration, Vector3 l_Position, float l_Height)
    {
        yield return new WaitForSeconds(transitionDuration);
        m_CharacterController.center = l_Position;
        m_CharacterController.height = l_Height;
    }
}
