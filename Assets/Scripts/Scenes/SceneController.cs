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

    public void RoomSetted(bool SettedRoom)
    {
        if (!SettedRoom) return;

        m_SettedRoom = SettedRoom;
        if (m_DoorToNextRoom != null)
            m_DoorToNextRoom.gameObject.SetActive(true);
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
        foreach (GameObject enemy in m_DoorToNextRoom.Enemies)
        {
            enemy.SetActive(true);
        }
    }
}
