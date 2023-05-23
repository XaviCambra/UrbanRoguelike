using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{
    public float m_RoomOffset = 20;

    [Header("Testing Tools")]
    [SerializeField, Tooltip("Selecciona esta casilla para generar una sala en concreto")] private bool m_CustomRoom = false;
    [SerializeField, Tooltip("Indica una sala para generarla, recuerda que necesitas tener la casilla 'Custom Room' activada")] private int m_RoomIndex = 0;

    [Range(1,3), Tooltip("Numero de habitaciones que van a generarse")] public int m_RoomCount = 3;

    private void Start()
    {
        GenerateRandomScene(m_RoomCount);
    }

    public void GenerateRandomScene(int l_RoomsLeft)
    {
        int RandomIndexScene;
        if (m_CustomRoom)
            RandomIndexScene = m_RoomIndex;
        else
            RandomIndexScene = Random.Range(1, 8);

        StartCoroutine(LoadRoom("Nivel_"+RandomIndexScene));

        l_RoomsLeft--;

        if (l_RoomsLeft > 0)
            GenerateRandomScene(l_RoomsLeft);
        else
            StartCoroutine(LoadRoom("Boss_Room"));
    }

    private IEnumerator LoadRoom(string l_Scene)
    {
        var asyncLoadLevel = SceneManager.LoadSceneAsync(l_Scene, LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }

        SetScenesOnPosition(l_Scene.Equals("Boss_Room"));
    }

    private void SetScenesOnPosition(bool l_GenerateNav)
    {
        GameObject[] l_Rooms = GameObject.FindGameObjectsWithTag("MainMap");

        for (int i = 0; i < l_Rooms.Length; i++)
        {
            SceneController l_SceneController = l_Rooms[i].GetComponent<SceneController>();
            if (l_SceneController.m_SettedRoom) continue;
            l_SceneController.m_SettedRoom = true;

            Vector3 l_MapPosition = Vector3.right * m_RoomOffset * i;
            l_Rooms[i].transform.position = l_MapPosition;

            l_SceneController.RoomSetted(true, l_GenerateNav);
        }
    }
}
