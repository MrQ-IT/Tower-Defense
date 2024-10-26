using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Image skillIcon;
    public Text skillNameText;
    public Text skillDescriptionText;
    public Text skillLevelText;
    public Text upgradeCostText;
    public Button upgradeButton;

    private int skillLevel = 1;
    private int upgradeCost = 50;
    private int playerGold = 100;

    // Hàm khởi tạo skill
    public void InitializeSkill(Sprite icon, string name, string description, int level, int cost)
    {
        skillIcon.sprite = icon;
        skillNameText.text = name;
        skillDescriptionText.text = description;
        skillLevel = level;
        upgradeCost = cost;
        UpdateSkillUI();
    }

    // Cập nhật UI kỹ năng
    void UpdateSkillUI()
    {
        skillLevelText.text = "Cấp độ: " + skillLevel.ToString();
        upgradeCostText.text = "Nâng cấp: " + upgradeCost.ToString() + " Gold";

        if (playerGold >= upgradeCost)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }

    // Xử lý nút nâng cấp
    public void OnUpgradeButtonClick()
    {
        if (playerGold >= upgradeCost)
        {
            playerGold -= upgradeCost;
            skillLevel++;
            upgradeCost += 20;
            UpdateSkillUI();
        }
    }

    // Hàm reset kỹ năng
    public void ResetSkill()
    {
        skillLevel = 1;
        upgradeCost = 50;
        UpdateSkillUI();
    }
}
