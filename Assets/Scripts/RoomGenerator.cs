using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{
    public float m_RoomOffset = 20;
    public int m_IndexRoomsGenerated = 0;

    private void Start()
    {
        GenerateRandomScene();
    }
    public void GenerateRandomScene()
    {
        int RandomIndexScene = (int)Random.Range(0, 2);
        SceneManager.LoadScene(RandomIndexScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(RandomIndexScene));
        GameObject[] l_Rooms = GameObject.FindGameObjectsWithTag("MainMap");
        m_IndexRoomsGenerated = l_Rooms.Length;
        foreach (GameObject RoomFound in l_Rooms)
        {
            SceneController l_SceneController = RoomFound.GetComponent<SceneController>();
            if (l_SceneController == null) return;
            if (l_SceneController.m_SettedRoom) return;

            Vector3 l_MapPosition = Vector3.right * m_RoomOffset * m_IndexRoomsGenerated;
            RoomFound.transform.position = l_MapPosition;

            l_SceneController.m_SettedRoom = true;
        }
    }
}
