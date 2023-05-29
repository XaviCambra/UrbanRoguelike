using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
//using UnityEditor.AI;
using UnityEngine.AI;

public class SceneController : MonoBehaviour
{
    public bool m_SettedRoom = false;

    public NavMeshSurface[] m_Surface;

    public GenerateNextRoom m_DoorToNextRoom;

    public void RoomSetted(bool l_SettedRoom, bool l_GenerateNav)
    {
        if (!l_SettedRoom) return;

        m_SettedRoom = l_SettedRoom;
        if (m_DoorToNextRoom != null)
        {
            StartCoroutine(ActivateEnemies(2.0f));
            m_DoorToNextRoom.gameObject.SetActive(true);
        }
        if(l_GenerateNav)
            UpdateNavigation();
    }

    public void UpdateNavigation()
    {
        foreach(NavMeshSurface surface in m_Surface)
        {
            surface.BuildNavMesh();
        }

        StartCoroutine(ActivateEnemies(2.0f));
    }

    private IEnumerator ActivateEnemies(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);

        if (m_DoorToNextRoom.Enemies.Length > 0)
        {
            foreach (GameObject enemy in m_DoorToNextRoom.Enemies)
            {
                if (enemy != null)
                    enemy.SetActive(true);
            }
        }

        
    }
}
