using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string l_Scene)
    {
        SceneManager.LoadSceneAsync(l_Scene);
    }

    public static void UnLoadScene(string l_Scene)
    {
        SceneManager.UnloadSceneAsync(l_Scene);
    }
}
