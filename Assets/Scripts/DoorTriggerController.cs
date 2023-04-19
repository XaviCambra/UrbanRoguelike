using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private Animator MyAnim = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                MyAnim.Play("DoorOpening", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                MyAnim.Play("DoorClosing", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
