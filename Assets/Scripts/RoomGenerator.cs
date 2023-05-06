using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{
    public void GenerateRandomScene()
    {
        SceneManager.LoadScene((int)Random.Range(0, 1), LoadSceneMode.Additive);
    }
}
