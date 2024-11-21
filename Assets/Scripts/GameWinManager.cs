using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour
{
    private int star;
    public Sprite[] starImage;
    public Sprite skillImage;

    // ki nang duoc mo khoa
    public SkillsSO SkillsSO;

    // du lieu cua map level 1
    public LevelSO LevelSO1;
    // du lieu cua map level 1
    public LevelSO levelSO2;

    // du lieu sao nang cap ki nang
    public StarSO starSO;

    public AchievementSO achievementSO;

    private void Start()
    {
        Initialize();
    }

    // khoi tao so sao dat duoc, skill duoc mo khoa va mo khoa map tiep theo
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

        if (LivesManager.main.lives == 20) achievementSO.defense = true;
        else achievementSO.defense = false;

        achievementSO.starsEarned += star;
        transform.Find("Star").GetComponent<Image>().sprite = starImage[star];
        transform.Find("Skill").GetComponent<Image>().sprite = skillImage;
        if (SceneManager.GetActiveScene().buildIndex < 8)
        {
            SkillsSO.islock = false;
        }
        if (SceneManager.GetActiveScene().buildIndex < 10)
        {
            levelSO2.islock = false;
        }
        LevelSO1.star = star;
        starSO.starCurrent += star;
    }

}
