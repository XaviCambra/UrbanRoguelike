using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDropper : BaseItem

{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private GameObject m_PlayerBulletOrigin;

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_PlayerBulletOrigin = GameObject.FindGameObjectWithTag("PlayerBulletOrigin");

        GameObject l_grenade = Instantiate(m_GrenadePrefab, m_PlayerBulletOrigin.transform.position, m_PlayerBulletOrigin.transform.rotation);
        Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
        l_rb.AddForce(m_PlayerBulletOrigin.transform.forward * m_MoveSpeed, ForceMode.VelocityChange);
        l_grenade.SetActive(true);

        Debug.Log("Granada creada");
    }
}
