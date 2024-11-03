using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{   
    public static LivesManager main;
    public int lives { get; set; }
    private Text text;

    void Start()
    {
        Initialize();
    }


    public void Initialize()
    {   
        main = this;
        lives = 20;
        text = GetComponentInChildren<Text>();
        text.text = lives.ToString();
    }

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;
            text.text = lives.ToString();
        }
        else
        {
            UIManager.main.GameOver();
        }
    }
}
