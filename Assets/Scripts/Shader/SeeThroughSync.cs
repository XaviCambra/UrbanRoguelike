using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material m_Material;
    public Camera m_Camera;
    public LayerMask m_LayerMask;

    private void Start()
    {
        m_Material.SetFloat(SizeID, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //var dir = m_Camera.transform.position - transform.position;
        //var ray = new Ray(transform.position, dir.normalized);

        //if (Physics.Raycast(ray, 3000, m_LayerMask))
        //    m_Material.SetFloat(SizeID, 1);
        //else
        //    m_Material.SetFloat (SizeID, 0);

        var view = m_Camera.WorldToViewportPoint(transform.position);
        m_Material.SetVector(PosID, view);
    }
}
