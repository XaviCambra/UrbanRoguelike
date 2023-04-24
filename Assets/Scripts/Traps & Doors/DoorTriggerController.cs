using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private Animator MyAnim = null;
    public bool m_Open = false;


    public void OpenDoor()
    {
        MyAnim.Play("DoorOpening", 0, 0.0f);
        m_Open = true;
        //gameObject.SetActive(false);
        Debug.Log("Door Opened");
    }

    public void CloseDoor()
    {
        MyAnim.Play("DoorClosing", 0, 0.0f);
        m_Open = false;
        //gameObject.SetActive(false);
        Debug.Log("Door Closed");
    }
}
