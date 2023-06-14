using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMaterial : MonoBehaviour
{
    [SerializeField] private List<Material> m_Material;
    [SerializeField] List<Material> m_LocalMaterial;

    MeshRenderer m_MeshRenderer;

    float m_DissolveSpeed;
    bool m_HasToDissapear = false;

    float m_Dissapear = -1.0f;

    private void Awake()
    {
        foreach(Material l_Material in m_Material)
        {
            m_LocalMaterial.Add(new Material(l_Material));
        }

        m_MeshRenderer = GetComponent<MeshRenderer>();
        
        for(int i = 0; i < m_MeshRenderer.materials.Length; i++)
        {
            m_MeshRenderer.materials[i] = m_LocalMaterial[i];
        }
        
        try
        {
            foreach (Material l_Material in m_LocalMaterial)
            {
                l_Material.SetFloat("_CharacterDissolve", -1);
            }
        }
        catch (Exception e) { };
    }

    public void Dissapear(float l_DissolveSpeed)
    {
        m_HasToDissapear = true;
        m_DissolveSpeed = l_DissolveSpeed;
    }

    private void Update()
    {
        if (!m_HasToDissapear)
            return;
        if (m_Dissapear >= 1)
            return;
        m_Dissapear += Time.deltaTime * m_DissolveSpeed;
        foreach (Material l_Material in m_MeshRenderer.materials)
        {
            try
            {
                l_Material.SetFloat("_CharacterDissolve", m_Dissapear);
                Debug.Log(l_Material.GetFloat("_CharacterDissolve"));
            }
            catch (Exception e) { };
        }
    }
}
