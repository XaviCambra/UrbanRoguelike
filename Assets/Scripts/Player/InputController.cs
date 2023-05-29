using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    public LayerMask m_PointerLayer;
    
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

    public Vector3 m_MouseDirectionScreen()
    {
        Vector3 m_MouseWorldPosition = Vector3.zero;

        RaycastHit hit;

        Ray l_ray = m_Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(l_ray, out hit, Mathf.Infinity, m_PointerLayer))
        {
            m_MouseWorldPosition = hit.point;
            Debug.DrawRay(m_Camera.transform.position, (hit.point - m_Camera.transform.position).normalized * hit.distance, Color.yellow);
        }

        m_MouseWorldPosition.y = transform.position.y;
        return (m_MouseWorldPosition - transform.position).normalized;
    }
}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
