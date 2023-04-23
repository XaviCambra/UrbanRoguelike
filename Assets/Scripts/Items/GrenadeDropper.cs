using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDropper : BaseItem
{
    [SerializeField] private float m_MoveSpeed;

    public GameObject m_GrenadePrefab;
    private GameObject m_Player;

    private bool m_UsedItem;

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_Player = GameObject.FindGameObjectWithTag("Player");

        GameObject l_grenade = Instantiate(m_GrenadePrefab, m_Player.transform.position, m_Player.transform.rotation);
        Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
        l_rb.AddForce(l_grenade.transform.forward * m_MoveSpeed, ForceMode.VelocityChange);

        Debug.Log("Granada creada");

        m_UsedItem = true;
    }
}
