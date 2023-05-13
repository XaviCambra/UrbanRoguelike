using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Coins : MonoBehaviour
{
    public TextMeshProUGUI m_Text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        m_Text.text = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetCurrentPoints().ToString();
    }
}
