using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlotController : MonoBehaviour
{
    public Image achievementIcon;       // Ảnh biểu tượng thành tựu
    public Text titleText;       // Text tiêu đề
    public Text descriptionText; // Text mô tả

    // Hàm để cập nhật trạng thái thành tựu
    public void UpdateAchievementStatus(bool isAchieved)
    {
        if (isAchieved)
        {
            // Nếu thành tựu đã đạt được, sáng lên
            achievementIcon.color = Color.white;
            titleText.color = new Color(1f, 1f, 0f);
            descriptionText.color = Color.white;
        }
        else
        {
            // Nếu chưa đạt, làm tối nhưng vẫn nhìn thấy chữ
            achievementIcon.color = new Color(0.5f, 0.5f, 0.5f, 0.6f); // Màu xám nhạt với độ trong suốt
            titleText.color = new Color(1f, 1f, 1f, 0.7f); // Màu trắng nhạt để vẫn đọc được
            descriptionText.color = new Color(1f, 1f, 1f, 0.7f); // Màu trắng nhạt để vẫn đọc được
        }
    }
}
