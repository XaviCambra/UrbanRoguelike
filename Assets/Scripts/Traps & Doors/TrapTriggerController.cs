using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggerController : MonoBehaviour
{
    //[SerializeField] private Animator MyAnim = null;

    [SerializeField] private GameObject player;

    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //MyAnim.Play("ActiveTrap", 0, 0.0f);
            player.GetComponent<Module_Health>().TakeDamage(damage);
        }
    }
}
