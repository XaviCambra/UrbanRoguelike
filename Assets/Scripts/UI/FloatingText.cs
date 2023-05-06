using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform m_Camera;
    Transform m_Origin;
    Transform m_Canvas;

    public Vector3 m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main.transform;
        m_Origin = transform.parent;

        m_Canvas = GameObject.FindObjectOfType<Canvas>().transform;
        transform.SetParent(m_Canvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - m_Camera.transform.position);
        transform.position = m_Origin.transform.position + m_Offset;
    }
}
