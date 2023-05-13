using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_Player;

    public float m_SmoothSpeed;
    public float m_OffsetOnDirection;

    public Vector3 m_CameraFarOffset;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        Vector3 l_PlayerPosition = m_Player.transform.position + m_CameraFarOffset;
        Vector3 l_desiredPosition = l_PlayerPosition + m_OffsetOnDirection * m_Player.GetComponent<InputController>().m_MouseDirectionScreen();
        Vector3 l_smoothedPosition = Vector3.Lerp(transform.position, l_desiredPosition, m_SmoothSpeed * Time.deltaTime);

        transform.position = l_smoothedPosition;
    }
}
