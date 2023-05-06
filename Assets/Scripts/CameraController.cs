using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_Player;

    public float m_SmoothSpeed;
    public Vector3 m_Offset;
   // public Quaternion m_Rotation;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.rotation = m_Rotation;
    }
    private void FixedUpdate()
    {
        Vector3 l_desiredPosition = m_Player.transform.position + m_Offset;
        Vector3 l_smoothedPosition = Vector3.Lerp(transform.position, l_desiredPosition, m_SmoothSpeed * Time.deltaTime);

        transform.position = l_smoothedPosition;
        //transform.rotation = m_Rotation;

        transform.LookAt(m_Player);
    }
}
