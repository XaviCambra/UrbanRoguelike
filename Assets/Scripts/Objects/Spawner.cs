using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnEnemyType
    {
        Mele,
        Ranged,
        Random
    }

    public SpawnEnemyType m_EnemyType;

    public GameObject m_MeleEnemy;
    public GameObject m_RangedEnemy;

    public void SpawnEnemy()
    {
        switch(m_EnemyType)
        {
            case SpawnEnemyType.Mele:
                Instantiate(m_MeleEnemy, m_MeleEnemy.transform); break;
            case SpawnEnemyType.Ranged:
                Instantiate(m_RangedEnemy, m_RangedEnemy.transform);break;
            case SpawnEnemyType.Random:
                int rand = Random.Range(0, 10);
                if (rand % 2 == 0)
                    Instantiate(m_MeleEnemy, m_MeleEnemy.transform);
                else
                    Instantiate(m_RangedEnemy, m_RangedEnemy.transform);
                break;
        }
    }
}
