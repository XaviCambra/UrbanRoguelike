using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMaterial : MonoBehaviour
{
    [SerializeField] private List<Material> m_Material;
    [SerializeField] List<Material> m_LocalMaterial;

    SkinnedMeshRenderer m_SkinnedMeshRenderer;
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

        m_SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        
        if(m_MeshRenderer != null)
        {
            for (int i = 0; i < m_SkinnedMeshRenderer.materials.Length; i++)
            {
                m_MeshRenderer.materials[i] = m_LocalMaterial[i];
            }
        }
        else
        {
            for (int i = 0; i < m_SkinnedMeshRenderer.materials.Length; i++)
            {
                m_SkinnedMeshRenderer.materials[i] = m_LocalMaterial[i];
            }
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

        if (m_MeshRenderer != null)
        {
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
        else
        {
            foreach (Material l_Material in m_SkinnedMeshRenderer.materials)
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
}
