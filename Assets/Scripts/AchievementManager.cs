using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementManager : MonoBehaviour
{
    public AchievementSlotController[] achievementSlots; // Mảng chứa các ô thành tựu

    //bool isAchieved = false;
    public AchievementSO[] achievementSO;
    void Start()
    {
        // Kiểm tra trạng thái của từng thành tựu khi bắt đầu
        for (int i = 0; i < achievementSO.Length ; i++)
        {
            int slotNomarl = i * 2;
            int slotHard = slotNomarl + 1;

            //// Cập nhật trạng thái cho achievement slot thông thường
            //CheckAchievement(slotNomarl, achievementSO[i].value, achievementSO[i].normalCondition);

            //// Cập nhật trạng thái cho achievement slot khó
            //CheckAchievement(slotHard, achievementSO[i].value, achievementSO[i].hardCondition);
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
