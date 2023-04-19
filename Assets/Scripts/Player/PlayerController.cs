using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    InputController m_InputController;
    Player_BLACKBOARD m_Blackboard;
    CharacterController m_CharacterController;

    private bool m_CanInteract;

    public BaseItem m_Item;

    private void Start()
    {
        m_CanInteract = true;
        m_InputController = GetComponent<InputController>();
        m_Blackboard = GetComponent<Player_BLACKBOARD>();
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(m_CanInteract == false) return;

        MovementInput();

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

        m_CharacterController.Move(l_Direction * m_Blackboard.m_MovementSpeed * Time.deltaTime);
    }

    void UseItem()
    {
        if (Input.GetKeyDown(m_InputController.m_UseItemKey))
        {
            m_Item.ApplyEffectItem();
        }
    }

    private void InvertInteract(bool isDead)
    {
        m_CanInteract = !isDead;
    }

    private void OnEnable()
    {
        try
        {
            gameObject.GetComponent<Module_Health>().m_PlayerIsDead += InvertInteract;
        }
        catch
        {
            Debug.LogWarning("Custom Warning - No Module_Health found on " +  gameObject.name);
        }
    }

    private void OnDisable()
    {
        try
        {
            gameObject.GetComponent<Module_Health>().m_PlayerIsDead -= InvertInteract;
        }
        catch
        {
            Debug.LogWarning("Custom Warning - No Module_Health found on " + gameObject.name);
        }
    }
}
