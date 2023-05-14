using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Crouch : MonoBehaviour
{
    private bool m_Crouching;

    private CharacterController m_CharacterController;
    private Module_Animation m_Animation;

    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    public bool AlternateCrouching(bool l_Crocuching)
    {
        if (l_Crocuching) Crouching_Out();
        else Crouching_In();
        return !l_Crocuching;
    }

    void Crouching_In()
    {
        //m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(0, m_CharacterController.center/2, m_CharacterController.height/2));
    }

    void Crouching_Out()
    {
        //float duration = m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(1, m_CharacterController.center*2, m_CharacterController.height*2));
    }

    IEnumerator ModifyCharacterCollider(float transitionDuration, Vector3 l_Position, float l_Height)
    {
        yield return new WaitForSeconds(transitionDuration);
        m_CharacterController.center = l_Position;
        m_CharacterController.height = l_Height;
    }
}