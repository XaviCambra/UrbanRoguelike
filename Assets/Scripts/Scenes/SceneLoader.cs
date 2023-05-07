using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string l_Scene)
    {
        SceneManager.LoadSceneAsync(l_Scene);
    }

    public void UnLoadScene(string l_Scene)
    {
        SceneManager.UnloadSceneAsync(l_Scene);
    }
}
