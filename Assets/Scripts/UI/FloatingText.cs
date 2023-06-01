using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform m_Camera;

    public Vector3 m_Offset;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_Camera.transform.position);
    }
}
