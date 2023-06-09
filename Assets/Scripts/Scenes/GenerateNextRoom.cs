using UnityEngine;

public class GenerateNextRoom : MonoBehaviour
{
    public GameObject[] Enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;

        if(Enemies.Length > 0)
        {
            foreach (GameObject enemy in Enemies)
            {
                if(enemy != null)
                {
                    if (enemy.activeSelf)
                        return;
                }
            }
        }

        GenerateNewRoom();
    }

    private void GenerateNewRoom()
    {
        Time.timeScale = 0;
        SceneLoader.LoadAdditiveScene("InGamePowerUp");
        //GameObject.FindObjectOfType<RoomGenerator>().GenerateRandomScene();
        Destroy(gameObject);
    }
}
