using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeeThroughSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    private Material m_Material;
    private Camera m_Camera;
    private Transform m_Player;

    private void Start()
    {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Material = GetComponent<MeshRenderer>().material;
        m_Material.SetFloat(SizeID, 1);
    }

    void Update()
    {
        Vector3 view = m_Camera.WorldToViewportPoint(m_Player.position);
        m_Material.SetVector(PosID, view);
    }
}
