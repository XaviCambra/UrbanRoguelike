using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public SpawnerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            controller.SpawnEnemies();
    }
}
