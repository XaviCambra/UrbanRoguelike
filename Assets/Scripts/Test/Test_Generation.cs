using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Test_Generation : MonoBehaviour
{
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

    // Use this for initialization
    void Update()
    {

        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }

        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}
