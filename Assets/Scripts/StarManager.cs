using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StarManager : MonoBehaviour
{
    [System.Serializable]
    public class Skills
    {
        public Button button;
        public Text title;
        public Text description;
        public int star;
        public Image imageButton;
    }

    public StarSkill[] skillData;
    public StarSO starSO;

    public Skills[] skills;
    public Text currentStarText;
    public Text buyStarText;
    public GameObject descriptionPanel;
    public Button buyButton;
    public Button resetButton;
    int selectSkillIndex = -1;
    //bool isBuy = false;

    string[] skillTitles = new string[]
    {
        "Spike Eruption",                         // Skill 1, Level 4
        "Lightning Cataclysm",                    // Skill 2, Level 4
        "Explosive Fury",                          // Skill 3, Level 4

        "Ground Spikes",                          // Skill 1, Level 3
        "Thunderstorm",                            // Skill 2, Level 3
        "Strong Bomb",                             // Skill 3, Level 3

        "Erupting Spikes",                        // Skill 1, Level 2
        "Stun Thunder",                            // Skill 2, Level 2
        "Area Bomb",                               // Skill 3, Level 2

        "Basic Spike",                             // Skill 1, Level 1
        "Basic Thunder",                           // Skill 2, Level 1
        "Small Bomb",                              // Skill 3, Level 1

        "Default Ground Spike",                               // Default Skill 1
        "Default Lightning",                                  // Default Skill 2
        "Default Weak Bomb"                                  // Default Skill 3
    };

    string[] skillTexts = new string[]
    {
        "Piercing spikes, maximum damage!",                // Skill 1, Level 4
        "Devastating lightning, obliterates everything!",   // Skill 2, Level 4
        "Massive explosive, maximum blast radius!",         // Skill 3, Level 4

        "Sharp spikes from the ground, high damage.",      // Skill 1, Level 3
        "Powerful thunder, widespread damage.",            // Skill 2, Level 3
        "Strong explosive, high damage.",                   // Skill 3, Level 3

        "Spikes erupt from below, medium damage.",         // Skill 1, Level 2
        "Stun lightning, moderate damage.",                // Skill 2, Level 2
        "Medium explosive, area damage.",                   // Skill 3, Level 2


        "Pointed spikes, basic damage.",                   // Skill 1, Level 1
        "Basic thunder, light damage.",                     // Skill 2, Level 1
        "Small explosive, basic damage.",                   // Skill 3, Level 1

        "Basic ground spike, low damage.",                  // Default Skill 1
        "Basic lightning, light stun effect.",              // Default Skill 2
        "Weak explosive, minimal destruction."              // Default Skill 3
    };


    // Start is called before the first frame update
    void Start()
    {
        currentStarText.text = "" + starSO.starCurrent;
        descriptionPanel.SetActive(false);

        // Đặt màu cho tất cả button thành màu đen
        for (int i = 0; i < skills.Length; i++)
        {
            if (skillData[i].isPurchased == true)
                skills[i].button.image.color = skillData[i].purchasedColor;
            else
                skills[i].button.image.color = new Color(0, 0, 0, 0.5f); // Đặt màu đen nếu chưa mua
        }

        // Thêm sự kiện click cho từng button
        for (int i = 0; i < skills.Length; i++)
        {
            int index = i; // Sử dụng biến tạm để tránh vấn đề với closure
            skills[i].button.onClick.AddListener(() => OnSkillButtonClicked(index));
        }

        if (buyButton != null)
        {
            buyButton.onClick.AddListener(OnBuyButtonClick);
        }
        resetButton.onClick.AddListener(ResetSkills);


    }

    void OnBuyButtonClick()
    {
        if (selectSkillIndex == -1)
        {
            Debug.Log("Chưa chọn kỹ năng nào.");
            return; // Không làm gì cả nếu chưa chọn kỹ năng
        }

        //int skillLevel = (9 - selectSkillIndex) % 3;
        //skillLevel = Mathf.Abs(skillLevel);

        // Kiểm tra xem cấp độ trước của hệ skill đã được mua chưa
        //if (selectSkillIndex < 3)
        //{
        //    Debug.Log("Cấp độ trước đó chưa được mua.");
        //    return;
        //}
        //else
        //{
        if (selectSkillIndex < 9 && skillData[(selectSkillIndex + 3)].isPurchased == false)
        {
            Debug.Log("Cấp độ trước đó chưa được mua.");
            return; // Nếu chưa mua cấp độ trước đó, không cho mua
        }
        //}

        // Xử lý sự kiện khi nhấp vào BuyButton
        if (starSO.starCurrent >= skills[selectSkillIndex].star && skillData[selectSkillIndex].isPurchased == false)
        {
            starSO.starCurrent -= skills[selectSkillIndex].star;
            currentStarText.text = starSO.starCurrent.ToString();
            //starSO.starCurrent = starSO.starCurrent;

            skillData[selectSkillIndex].isPurchased = true; // Đánh dấu kỹ năng đã mua

            if (selectSkillIndex < 3)
            {
                skills[selectSkillIndex].button.image.color = new Color(0.835f, 0f, 1f);
                skillData[selectSkillIndex].purchasedColor = new Color(0.835f, 0f, 1f);
            }
            else
                if (selectSkillIndex < 6)
            {
                skills[selectSkillIndex].button.image.color = new Color(0.361f, 0.871f, 0.400f);
                skillData[selectSkillIndex].purchasedColor = new Color(0.361f, 0.871f, 0.400f);
            }
            else
                if (selectSkillIndex < 9)
            {
                skills[selectSkillIndex].button.image.color = new Color(1f, 0.859f, 0f);
                skillData[selectSkillIndex].purchasedColor = new Color(1f, 0.859f, 0f);
            }
            else
            {
                skills[selectSkillIndex].button.image.color = new Color(0.737f, 0.674f, 0.674f, 0.737f);
                skillData[selectSkillIndex].purchasedColor = new Color(0.737f, 0.674f, 0.674f, 0.737f);
            }

            Debug.Log("Mua thành công!");
        }
        else
        {
            Debug.Log("Không đủ sao để mua.");
        }
    }

    void ResetSkills()
    {
        // Lưu lại số sao đã chi tiêu trong quá trình mua kỹ năng
        for (int i = 0; i < skills.Length; i++)
        {
            if (skillData[i].isPurchased == true)
            {
                starSO.starCurrent += skills[i].star; // Cộng dồn số sao đã chi tiêu
            }
        }
        currentStarText.text = starSO.starCurrent.ToString();

        // Đặt lại trạng thái các kỹ năng về chưa mua
        for (int i = 0; i < skills.Length; i++)
        {
            skillData[i].isPurchased = false; // Đặt trạng thái kỹ năng về chưa mua
            skills[i].button.image.color = new Color(0, 0, 0, 0.5f); // Đặt màu button về đen (chưa mua)
        }

        // Đặt lại selectSkillIndex để không chọn kỹ năng nào
        selectSkillIndex = -1;
        descriptionPanel.SetActive(false); // Tắt panel mô tả
    }

    void OnSkillButtonClicked(int index)
    {
        selectSkillIndex = index;

        // Cập nhật title và description cho skill đã chọn
        skills[index].title.text = skillTitles[index];
        skills[index].description.text = skillTexts[index];
        buyStarText.text = "" + skills[index].star;

        for (int i = 0; i < skills.Length; i++)
        {
            if (i == index && skillData[i].isPurchased == false)
                skills[i].button.image.color = new Color(1f, 1f, 1f, 0.5f); // sang button
            else if (skillData[i].isPurchased == false)
            {
                // Trở lại màu ban đầu (màu đen) nếu chưa mua
                skills[i].button.image.color = new Color(0, 0, 0, 0.5f);
            }
        }

        descriptionPanel.SetActive(true);
    }

}