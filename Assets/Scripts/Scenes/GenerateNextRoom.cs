using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateNextRoom : MonoBehaviour
{
    public GameObject[] Enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;

        foreach (GameObject enemy in Enemies)
        {
            if (enemy.activeSelf)
                return;
        }

        GenerateNewRoom();
    }

    private void GenerateNewRoom()
    {
        Time.timeScale = 0;
        SceneLoader.LoadAdditiveScene("InGamePowerUp");
        //FindAnyObjectByType(typeof(RoomGenerator)).GetComponent<RoomGenerator>().GenerateRandomScene();
        Destroy(gameObject);
    }
}
