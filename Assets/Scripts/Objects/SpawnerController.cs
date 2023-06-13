using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> m_SpawnerList;

    public void SpawnEnemies()
    {
        foreach(Spawner spawner in m_SpawnerList)
        {
            spawner.SpawnEnemy();
        }
    }
}
