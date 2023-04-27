using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;

    public GameObject m_test;
    
    [Header("Inputs")]
    public KeyCode m_ForwardKey = KeyCode.W;
    public KeyCode m_LeftKey = KeyCode.A;
    public KeyCode m_BackKey = KeyCode.S;
    public KeyCode m_RightKey = KeyCode.D;
    
    //Crouch
    public KeyCode m_CrouchingKey = KeyCode.LeftControl;
    
    //Dash
    public KeyCode m_DashKey = KeyCode.Space;

    //Use Item
    public KeyCode m_UseItemKey = KeyCode.Q;

    //Swap Item
    public KeyCode m_SwapItemKey = KeyCode.Tab;

    //Drop Item
    public KeyCode m_DropItemKey = KeyCode.X;

    //Shoot
    public MouseButton m_ShootButton = MouseButton.Left;

    public Vector3 m_MousePositionRay()
    {
        //Ray l_ray = m_MousePositionRay();

        Vector3 l_mouseScreenPosition = Input.mousePosition;
        Vector3 m_MouseWorldPosition = Vector3.zero;

        Ray l_ray = m_Camera.ScreenPointToRay(l_mouseScreenPosition);


        if (Physics.Raycast(l_ray, out RaycastHit l_Hit))
        {
            m_MouseWorldPosition = l_Hit.point;
        }
        //return m_Camera.ScreenPointToRay(m_MouseWorldPosition);
        return m_MouseWorldPosition;
    }

    public Vector3 m_VectorToMouse(Vector3 l_StartPoint)
    {
        return Input.mousePosition - l_StartPoint;
    }

    public Vector3 m_MousePosition()
    {
        return Input.mousePosition;
    }
}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
