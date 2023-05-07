using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator = null;
    public bool m_Open = false;
    public GameObject m_FloatingText;

    KeyItem m_key;

    public void OpenDoor()
    {
        m_Animator.Play("DoorOpening", 0, 0.0f);
        m_Open = true;
        //gameObject.SetActive(false);
        m_FloatingText.SetActive(false);
        Debug.Log("Door Opened");
    }

    public void CloseDoor()
    {
        m_Animator.Play("DoorClosing", 0, 0.0f);
        m_Open = false;
        //gameObject.SetActive(false);
        Debug.Log("Door Closed");
    }

    private void OnTriggerEnter(Collider other)
    {
        Player_BLACKBOARD l_blackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        if (other.CompareTag("Player") && l_blackboard.m_HasKey)
        {
            m_FloatingText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_FloatingText.SetActive(false);
    }
}
