using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour
{
    public int star { get; set; }
    public Sprite[] starImage;
    public Sprite skillImage;
    public SkillsSO SkillsSO;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (LivesManager.main.lives >= 17)
        {
            star = 3;
        }
        else if (LivesManager.main.lives >= 10)
        {
            star = 2;
        }
        else if (LivesManager.main.lives >= 1)
        {
            star = 1;
        }
        else
        {
            star = 0;
        }
        transform.Find("Star").GetComponent<Image>().sprite = starImage[star];
        transform.Find("Skill").GetComponent<Image>().sprite = skillImage;
        SkillsSO.islock = false;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void NextButton()
    {
        SceneManager.LoadScene("Level 2");
    }
}
