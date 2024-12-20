using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementManager : MonoBehaviour
{
    public AchievementSlotController[] achievementSlots; // Mảng chứa các ô thành tựu

    //bool isAchieved = false;
    public AchievementSO achievementSO;
    void Start()
    {
        // Kiểm tra trạng thái của từng thành tựu khi bắt đầu
        for (int i = 0; i < achievementSlots.Length; i++)
        {
            switch (i)
            {
                case 0:
                    CheckAchievement(i, achievementSO.kills, 1);
                    break;
                case 1:
                    CheckAchievement(i, achievementSO.kills, 200);
                    break;
                case 2:
                    CheckAchievement(i, achievementSO.builds, 10);
                    break;
                case 3:
                    CheckAchievement(i, achievementSO.builds, 100);
                    break;
                case 4:
                    CheckAchievement(i, achievementSO.useSkill, 1);
                    break;
                case 5:
                    CheckAchievement(i, achievementSO.useSkill, 50);
                    break;
                case 6:
                    CheckAchievement(i, achievementSO.starsEarned, 3);
                    break;
                case 7:
                    CheckAchievement(i, achievementSO.starsEarned, 15);
                    break;
                case 8:
                    int j = 0;
                    if (achievementSO.normalSkill == true) j = 1;
                    CheckAchievement(i, j, 1);
                    break;
                case 9:
                    int k = 0;
                    if (achievementSO.hardSkill == true) k = 1;
                    CheckAchievement(i, k, 2);
                    break;
                case 10:
                    int z = 0;
                    if (achievementSO.defense == true) z = 1;
                    CheckAchievement(i, z, 1);
                    break;
                default:
                    Debug.Log("Loi thanh tuu");
                    break;
            }
        }
    }

    void CheckAchievement(int slotIndex, int currentValue, int conditionValue)
    {
        if (slotIndex < achievementSlots.Length)
        {
            if (currentValue >= conditionValue)
            {
                achievementSlots[slotIndex].UpdateAchievementStatus(true);
            }
            else
            {
                achievementSlots[slotIndex].UpdateAchievementStatus(false);
            }
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Level Select");
    }
}
