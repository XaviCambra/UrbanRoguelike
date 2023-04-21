using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private Animator MyAnim = null;


    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController == null) return;

        if(playerController.m_Item == null /*ItemDeLlave*/)
        {
            MyAnim.Play("DoorOpening", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }
}
