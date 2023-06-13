using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public SpawnerController controller;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            controller.SpawnEnemies();
            gameObject.SetActive(false);
        }
    }
}
