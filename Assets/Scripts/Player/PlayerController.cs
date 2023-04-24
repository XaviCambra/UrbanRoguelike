using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    InputController m_InputController;
    Player_BLACKBOARD m_Blackboard;
    CharacterController m_CharacterController;

    Module_Animation m_Animation;

    private bool m_CanInteract;
    private bool m_Crouching;

    

    private float m_MovementSpeed;

    private void Start()
    {
        m_CanInteract = true;
        m_InputController = GetComponent<InputController>();
        m_Blackboard = GetComponent<Player_BLACKBOARD>();
        m_CharacterController = GetComponent<CharacterController>();
        m_Animation = GetComponent<Module_Animation>();

        m_Crouching = false;

        m_MovementSpeed = m_Blackboard.m_MovementSpeed;
    }

    private void Update()
    {
        if(m_CanInteract == false) return;

        MovementInput();
        Crouching();

        UseItem();
    }

    void MovementInput()
    {
        Vector3 l_Direction = Vector3.zero;

        if (Input.GetKey(m_InputController.m_ForwardKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.forward;
        }
        if (Input.GetKey(m_InputController.m_BackKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.back;
        }
        if (Input.GetKey(m_InputController.m_LeftKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.left;
        }
        if (Input.GetKey(m_InputController.m_RightKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.right;
        }

        l_Direction.Normalize();

        l_Direction = Module_LinearGravity.SetGravityToVector(l_Direction);

        l_Direction = l_Direction * m_MovementSpeed * Time.deltaTime;

        m_CharacterController.Move(l_Direction);
    }

    void UseItem()
    {
        if (Input.GetKeyDown(m_InputController.m_UseItemKey))
        {
            if (m_Blackboard.m_Item == null) return;

            m_Blackboard.m_Item.ApplyEffectItem();
        }
    }

    void Crouching()
    {
        if (Input.GetKeyDown(m_InputController.m_CrouchingKey))
        {
            if (m_Crouching) Crouching_Out();
            else Crouching_In();

        }
    }

    void SetSpeed()
    {
        if (m_Crouching)
        {
            m_MovementSpeed = m_Blackboard.m_MovementSpeed;
        }
        else if (!m_Crouching)
        {
            m_MovementSpeed = m_Blackboard.m_CrouchingSpeed;
        }
    }

    void Crouching_In()
    {
        float duration = m_Animation.PlayAnimation("Crouching", m_Crouching);
        
        StartCoroutine(ModifyCharacterCollider(duration/2, new Vector3(0, 1, 0), 2));
        SetSpeed();
        m_Crouching = true;
    }

    void Crouching_Out()
    {
        m_Animation.PlayAnimation("Crouching", m_Crouching);
        
        StartCoroutine(ModifyCharacterCollider(0, new Vector3(0, 0.5f, 0), 1));
        SetSpeed();
        m_Crouching = false;
    }

    IEnumerator ModifyCharacterCollider(float transitionDuration, Vector3 l_Position, float l_Height)
    {
        yield return new WaitForSeconds(transitionDuration);
        m_CharacterController.center = l_Position;
        m_CharacterController.height = l_Height;
    }

    private void InvertInteract(bool isDead)
    {
        m_CanInteract = !isDead;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Module_Health>().m_PlayerIsDead += InvertInteract;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Module_Health>().m_PlayerIsDead -= InvertInteract;
    }
}
