using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            player.GetComponent<Module_Health>().GetHeal(heal);
            
        }
    }
}
