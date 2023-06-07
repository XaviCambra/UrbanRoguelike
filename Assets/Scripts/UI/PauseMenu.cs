using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ReanudeGame()
    {
        Time.timeScale = 1;
        SceneLoader.UnLoadScene("PauseMenu");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneLoader.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneLoader.Quit();
    }
}
