using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Vector3 m_MouseScreenPosition;
    [SerializeField] private Vector3 m_MouseWorldPosition;

    [SerializeField] private Camera m_Camera;

    public GameObject m_test;
    
    [Header("Inputs")]
    public KeyCode m_ForwardKey = KeyCode.W;
    public KeyCode m_BackKey = KeyCode.S;
    public KeyCode m_LeftKey = KeyCode.A;
    public KeyCode m_RightKey = KeyCode.D;
    //Crouch
    public KeyCode m_CrouchingKey = KeyCode.LeftShift;
    //Item
    public KeyCode m_UseItemKey = KeyCode.Q;

    private void Update()
    {
        m_MouseScreenPosition = Input.mousePosition;

        /*m_MouseScreenPosition.z = m_Camera.nearClipPlane;

        m_MouseWorldPosition = m_Camera.ScreenToWorldPoint(m_MouseScreenPosition);*/

        Ray l_ray = m_Camera.ScreenPointToRay(m_MouseScreenPosition);

        if (Physics.Raycast(l_ray, out RaycastHit l_Hit))
        {
            m_MouseWorldPosition = l_Hit.point;
        }

        Debug.Log(m_MouseWorldPosition);

        if (Input.GetMouseButtonDown((int) MouseButton.Left))
        {
            Instantiate(m_test, m_MouseWorldPosition, Quaternion.Euler(0, 0, 0));
        }
    }
}

public enum MouseButton
{
    Left = 0,
    Center = 2,
    Right = 1
}
