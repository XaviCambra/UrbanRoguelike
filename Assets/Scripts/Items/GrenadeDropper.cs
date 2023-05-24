using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDropper : BaseItem

{
    [SerializeField] private GameObject m_GrenadePrefab;
    [SerializeField] private GameObject m_PlayerBulletOrigin;
    [SerializeField] private Player_BLACKBOARD m_PlayerBlackboard;
    [SerializeField] private Transform m_PlayerTransform;
    GameObject m_grenade;

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

        m_PlayerBulletOrigin = GameObject.FindGameObjectWithTag("PlayerBulletOrigin");
        m_InventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();     
        m_PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();      


        m_DropperCollider = GetComponent<BoxCollider>();
        m_DropperCollider.isTrigger = true;

        
        GameObject m_grenade = Instantiate(m_GrenadePrefab, m_PlayerBulletOrigin.transform.position, m_PlayerBulletOrigin.transform.rotation);
        m_PlayerBlackboard.m_HasGrenade = true;

        m_grenade.SetActive(true);
        m_grenade.transform.SetParent(m_PlayerTransform);

        Debug.Log("Granada creada");

        m_InventoryManager.UseItem();
    }
}
