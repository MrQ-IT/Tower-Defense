using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    private int lives;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
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
    }
}
