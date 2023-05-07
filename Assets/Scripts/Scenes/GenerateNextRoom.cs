using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateNextRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") == false) return;
        FindAnyObjectByType(typeof(RoomGenerator)).GetComponent<RoomGenerator>().GenerateRandomScene();
        Destroy(gameObject);
    }
}
