using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public static bool LevelCompleted = false;
    public int levelCurrent = 0;

    public void FinishLevel()
    {
        LevelCompleted = true;
        SceneManager.LoadScene("Level Select");
    }
    public void ResetLevel()
    {
        LevelCompleted = false;
        SceneManager.LoadScene("Level Select");

    }
    public bool CheckLevelComp()
    {
        return LevelCompleted;
    }
    public int levelCompCurrent()
    {
        return levelCurrent;
    }
}
