using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public bool m_SettedRoom = false;

    public GameObject m_DoorToNextRoom;

    public void RoomSetted(bool SettedRoom)
    {
        if (!SettedRoom) return;

        m_SettedRoom = SettedRoom;
        m_DoorToNextRoom.SetActive(true);
    }
}
