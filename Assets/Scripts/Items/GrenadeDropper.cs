using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDropper : BaseItem

{
    [SerializeField] private float m_MoveSpeed;

    public GameObject m_GrenadePrefab;
    [SerializeField] private GameObject m_PlayerMesh;

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
       
        GameObject l_grenade = Instantiate(m_GrenadePrefab, m_PlayerMesh.transform.position, m_PlayerMesh.transform.rotation);
        Rigidbody l_rb = l_grenade.GetComponent<Rigidbody>();
        l_rb.AddForce(m_PlayerMesh.transform.forward * m_MoveSpeed, ForceMode.VelocityChange);
        l_grenade.SetActive(true);

        Debug.Log("Granada creada");
    }
}
