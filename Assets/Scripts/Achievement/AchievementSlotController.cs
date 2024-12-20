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

    private Color achievedTitleColor = new Color(1f, 1f, 0f); // Màu vàng
    private Color defaultIconColor = new Color(0.5f, 0.5f, 0.5f, 0.6f);// Màu xám nhạt với độ trong suốt
    private Color defaultColor = Color.white; // Màu trắng

    public void UpdateAchievementStatus(bool isAchieved)
    {

        if (isAchieved)
        {
            // Nếu thành tựu đã đạt được, sáng lên
            achievementIcon.color = defaultColor;
            titleText.color = achievedTitleColor;
            descriptionText.color = defaultColor;
        }
        else
        {
            // Nếu chưa đạt, làm tối icon nhưng vẫn nhìn thấy chữ
            achievementIcon.color = defaultIconColor;
            titleText.color = defaultColor;
            descriptionText.color = defaultColor;
        }
    }
}