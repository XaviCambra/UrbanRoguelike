using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class GenerateNav : MonoBehaviour
{
    public GameObject[] Enemies;

    public void UpdateNavigation()
    {
        NavMeshBuilder.BuildNavMeshAsync();
        StartCoroutine(ActivateEnemies(2.5f));
    }

    private IEnumerator ActivateEnemies(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        foreach(GameObject enemy in Enemies)
        {
            enemy.SetActive(true);
        }
    }

}