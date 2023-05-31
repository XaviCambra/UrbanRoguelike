using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileFollow : MonoBehaviour
{
    public float m_FollowSpeed;
    public GameObject m_Player;
    public Misile m_Misile;
    private bool m_CanMove = true;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FollowTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_CanMove)
            return;

        Vector3 l_Direction = m_Player.transform.position - transform.position;
        l_Direction.Normalize();
        Vector3 l_Displacement;
        if (Vector3.Distance(m_Player.transform.position, transform.position) > m_FollowSpeed)
            l_Displacement = l_Direction * m_FollowSpeed;
        else
            l_Displacement = l_Direction * Vector3.Distance(m_Player.transform.position, transform.position);
        transform.Translate(l_Displacement);
    }

    private IEnumerator FollowTime()
    {
        yield return new WaitForSeconds(m_Misile.m_TimeToFallDown * 0.9f);
        m_CanMove = false;
    }
}
