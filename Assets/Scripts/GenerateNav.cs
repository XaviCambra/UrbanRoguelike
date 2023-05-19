using System.Collections;
using System.Collections.Generic;
//using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class GenerateNav : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;
    public GameObject[] Enemies;

    public void UpdateNavigation()
    {
        navMeshSurface.BuildNavMesh();
        //NavMeshBuilder.BuildNavMeshAsync();
        StartCoroutine(ActivateEnemies(4.0f));
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
