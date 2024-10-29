using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementSlotController[] achievementSlots; // Mảng chứa các ô thành tựu

    public int killCount = 1;

    void Start()
    {
        // Kiểm tra trạng thái của từng thành tựu khi bắt đầu
        for (int i = 0; i < achievementSlots.Length; i++)
        {
            bool isAchieved = (i == 0) ? (killCount > 0) : CheckAchievementStatus(i);
            achievementSlots[i].UpdateAchievementStatus(isAchieved);

            // Lưu trạng thái thành tựu đầu tiên
            if (i == 0 && killCount > 0)
            {
                PlayerPrefs.SetInt("Achievement_0", 1);
            }
        }
    }

    // Hàm giả định kiểm tra trạng thái thành tựu
    bool CheckAchievementStatus(int index)
    {
        // Ở đây, bạn có thể dùng dữ liệu người chơi để xác định trạng thái
        return PlayerPrefs.GetInt("Achievement_" + index, 0) == 1;
    }
}
