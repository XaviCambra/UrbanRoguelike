using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileIndicator : MonoBehaviour
{
    public Misile m_Misile;
    public float m_EndSize;

    // Start is called before the first frame update
    void Start()
    {
        if(m_Misile == null)
        {
            Debug.LogError("No misile setted");
            return;
        }
        StartCoroutine(MisileScaleIndicator());
    }


    private IEnumerator MisileScaleIndicator()
    {
        float t = 0.0f;
        float l_TimeRate = 1f / (m_Misile.m_TimeToFallDown * 0.9f);
        Vector3 l_InitialScale = transform.localScale;
        Vector3 l_EndScale = new Vector3(m_EndSize, m_EndSize, m_EndSize);
        while (transform.position != l_InitialScale)
        {
            t += Time.deltaTime * l_TimeRate;
            transform.localScale = Vector3.Lerp(l_InitialScale, l_EndScale, t);
            yield return null;
        }
    }
}
