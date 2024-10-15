using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        health = 20;
    }

    private void LoseHealth()
    {
        if (health > 0)
        {
            health -= 1;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {

    }
}
