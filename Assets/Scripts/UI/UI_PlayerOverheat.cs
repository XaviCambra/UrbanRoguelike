using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerOverheat : MonoBehaviour
{
    Player_BLACKBOARD m_PlayerBlackboard;

    public List<Image> BulletImageList;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerBlackboard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();

        for (int i = 0; i < BulletImageList.Count; i++)
        {
            BulletImageList[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerBlackboard == null)
            return;

        updateBulletsImages();
    }
    void updateBulletsImages()
    {
        for (int i = 0; i < m_PlayerBlackboard.m_MaxOverHeat; i++)
        {
            BulletImageList[i].enabled = true;
        }

        for (int i = 0; i < m_PlayerBlackboard.m_CurrentShots; i++)
        {
            BulletImageList[i].enabled = false;
        }
    }
}
