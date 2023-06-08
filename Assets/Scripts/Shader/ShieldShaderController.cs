using System.Collections;
using UnityEngine;

public class ShieldShaderController : MonoBehaviour
{
    public float m_DissolveSpeed;

    private float m_DissolvePercent;

    public Material m_DissolveMaterial;

    private void Start()
    {
        m_DissolvePercent = 1f;

        m_DissolveMaterial.SetFloat("_AlphaClipBubble", m_DissolvePercent);
    }

    public void Appear()
    {
        StartCoroutine(ShieldOn());
    }

    public void Dissapear()
    {
        StartCoroutine(ShieldOff());
    }

    private IEnumerator ShieldOn()
    {
        while (m_DissolvePercent > -0.5f) 
        {
            m_DissolvePercent -= Time.deltaTime * m_DissolveSpeed;
            m_DissolveMaterial.SetFloat("_AlphaClipBubble", m_DissolvePercent);
            yield return null;
        }
    }

    private IEnumerator ShieldOff()
    {
        while (m_DissolvePercent < 1)
        {
            m_DissolvePercent += Time.deltaTime * m_DissolveSpeed;
            m_DissolveMaterial.SetFloat("_AlphaClipBubble", m_DissolvePercent);
            yield return null;
        }
    }
}

