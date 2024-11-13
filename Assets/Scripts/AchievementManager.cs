using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementManager : MonoBehaviour
{
    public AchievementSlotController[] achievementSlots; // Mảng chứa các ô thành tựu

    bool isAchieved = false;
    public AchievementSO[] achievementSO;
    void Start()
    {
        int killCount = PlayerPrefs.GetInt("KillCount", 0);

        // Kiểm tra trạng thái của từng thành tựu khi bắt đầu
        for (int i = 0; i < achievementSlots.Length; i++)
        {

            if (achievementSO[0].value >= achievementSO[0].condition && i == 0) isAchieved = true;
            else isAchieved = false;

            if (achievementSO[0].value >= 5 && i == 1) isAchieved = true;

            if (achievementSO[1].value >= achievementSO[1].condition && i == 2) isAchieved = true;
            if (achievementSO[1].value >= 5 && i == 3) isAchieved = true;

            achievementSlots[i].UpdateAchievementStatus(isAchieved);

        }
    }

        public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
