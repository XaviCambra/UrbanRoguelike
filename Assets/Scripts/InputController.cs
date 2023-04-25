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
    public KeyCode m_CrouchingKey = KeyCode.LeftShift;
    
    //Use Item
    public KeyCode m_UseItemKey = KeyCode.Q;

    //Swap Item
    public KeyCode m_SwapItemKey = KeyCode.Tab;

    //Drop Item
    public KeyCode m_DropItemKey = KeyCode.X;

    //Shoot
    public MouseButton m_ShootButton = MouseButton.Left;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int) MouseButton.Right))
        {
            Vector3 l_MouseScreenPosition = Input.mousePosition;

            Ray l_ray = m_Camera.ScreenPointToRay(l_MouseScreenPosition);

            Vector3 l_MouseWorldPosition = Vector3.zero;

            if (Physics.Raycast(l_ray, out RaycastHit l_Hit))
            {
                l_MouseWorldPosition = l_Hit.point;
            }

            Instantiate(m_test, l_MouseWorldPosition, Quaternion.Euler(0, 0, 0));
        }
    }
}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
