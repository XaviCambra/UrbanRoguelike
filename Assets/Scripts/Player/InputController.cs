using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    public LayerMask m_PointerLayer;
    
    [Header("Inputs")]
    [Header("Movement")]
    public KeyCode m_ForwardKey = KeyCode.W;
    public KeyCode m_LeftKey = KeyCode.A;
    public KeyCode m_BackKey = KeyCode.S;
    public KeyCode m_RightKey = KeyCode.D;

    [Header("Crouch")]
    public KeyCode m_CrouchingKey = KeyCode.LeftControl;

    [Header("Dash")]
    public KeyCode m_DashKey = KeyCode.Space;

    [Header("Use Item")]
    public KeyCode m_UseItemKey = KeyCode.Q;

    [Header("Swap Item")]
    public KeyCode m_SwapItemKey = KeyCode.Tab;

    [Header("Drop Item")]
    public KeyCode m_DropItemKey = KeyCode.X;

    [Header("Shoot")]
    public MouseButton m_ShootButton = MouseButton.Left;

    [Header("Pause")]
    public KeyCode m_PauseButton = KeyCode.Escape;

    public Vector3 m_MousePositionWorld()
    {
        Vector3 m_MouseWorldPosition = Vector3.zero;

        RaycastHit hit;

        Ray l_ray = m_Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(l_ray, out hit, Mathf.Infinity, m_PointerLayer))
        {
            m_MouseWorldPosition = hit.point;
            if (hit.collider.gameObject.tag == "Enemy")
                m_MouseWorldPosition = hit.collider.transform.position;
            Debug.DrawRay(m_Camera.transform.position, (m_MouseWorldPosition - m_Camera.transform.position).normalized * hit.distance, Color.yellow);
        }

        m_MouseWorldPosition.y = transform.position.y;
        return m_MouseWorldPosition;
    }

    public Vector3 m_MouseDirectionScreen()
    {
        Vector3 m_MouseWorldPosition = Vector3.zero;

        RaycastHit hit;

        Ray l_ray = m_Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(l_ray, out hit, Mathf.Infinity, m_PointerLayer))
        {
            m_MouseWorldPosition = hit.point;
            if (hit.collider.gameObject.tag == "Enemy")
                m_MouseWorldPosition = hit.collider.transform.position;
            Debug.DrawRay(m_Camera.transform.position, (m_MouseWorldPosition - m_Camera.transform.position).normalized * hit.distance, Color.yellow);
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
