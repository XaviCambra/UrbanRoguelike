using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Vector3 m_MouseScreenPosition;
    [SerializeField] private Vector3 m_MouseWorldPosition;

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

    private void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public Vector3 m_MouseDirectionScreen()
    {
        Vector3 m_MouseWorldPosition = m_MousePositionInScreen();

        m_MouseWorldPosition.y = transform.position.y;

        return (m_MouseWorldPosition - transform.position).normalized;
    }

    public Vector3 m_MousePositionInScreen()
    {
        Vector3 l_mouseScreenPosition = Input.mousePosition;

        Ray l_ray = m_Camera.ScreenPointToRay(l_mouseScreenPosition);

        if (Physics.Raycast(l_ray, out RaycastHit l_Hit))
        {
            Vector3 l_HitPoint = l_Hit.point;
            Debug.DrawRay(m_Camera.transform.position, l_HitPoint, Color.yellow);
            return l_HitPoint;
        }

        return Vector3.zero;
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
