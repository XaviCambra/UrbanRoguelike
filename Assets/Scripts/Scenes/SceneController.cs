using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class SceneController : MonoBehaviour
{
    public bool m_SettedRoom = false;

    public GenerateNextRoom m_DoorToNextRoom;

    public void RoomSetted(bool SettedRoom)
    {
        if (!SettedRoom) return;

        m_SettedRoom = SettedRoom;
        m_DoorToNextRoom.gameObject.SetActive(true);
        UpdateNavigation();
    }

    public void UpdateNavigation()
    {
        NavMeshBuilder.BuildNavMeshAsync();
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
