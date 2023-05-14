using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Crouch : MonoBehaviour
{
    private bool m_Crouching;

    private CharacterController m_CharacterController;
    private Module_Animation m_Animation;

    public bool AlternateCrouching()
    {
        if (m_Crouching) Crouching_Out();
        else Crouching_In();
        return m_Crouching;
    }

    void Crouching_In()
    {
        m_Crouching = true;
        m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(0, new Vector3(0, 0.5f, 0), 1));
    }

    void Crouching_Out()
    {
        m_Crouching = false;
        float duration = m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(duration / 2, new Vector3(0, 1, 0), 2));
    }

    IEnumerator ModifyCharacterCollider(float transitionDuration, Vector3 l_Position, float l_Height)
    {
        yield return new WaitForSeconds(transitionDuration);
        m_CharacterController.center = l_Position;
        m_CharacterController.height = l_Height;
    }
}
