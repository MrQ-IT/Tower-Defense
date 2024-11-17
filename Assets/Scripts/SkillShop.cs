using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SkillShop : MonoBehaviour
{
    public static SkillShop Instance;

    // giao dien
    [SerializeField] private Text starCurrency; // tong so sao
    [SerializeField] private Text skillName; // ten ki nang
    [SerializeField] private Text description; // mo ta cua ki nang
    [SerializeField] private Text skillStars; // so sao de mua ki nang

    // button
    [SerializeField] private SkillShopButton[] skillShopButton;

    // du lieu
    [SerializeField] private StarSO starSO; // du lieu tong so sao
    [SerializeField] private SkillsSO[] skillsSO;

    // sao de mua ki nang
    private int stars;

    private void Start()
    {
        Instance = this;
        UpdateStar();
        InitializeSkillButtons();
    }

    // su kien cho 2 button
    public void ResetButton()
    {

    }

    public void BuyButton()
    {
        for (int i = 0; i < skillShopButton.Length; i++)
        {
            SkillShopButton sb = skillShopButton[i];
            if (sb.GetSkillName() == skillName.text && !sb.GetPurchased() && starSO.starCurrent >= sb.GetStar())
            {
                sb.SetActivePurchased(true);
                sb.SetPurchased(true);
                starSO.starCurrent -= stars;
                starCurrency.text = starSO.starCurrent.ToString();
                int index = sb.GetSkillType();
                UpgradeSkill(index, skillsSO[index].cooldown * 0.2f,
                    Mathf.FloorToInt(skillsSO[index].damage * 0.2f), 0.2f);
            }
            else
            {
                Debug.Log("Can't buy skill");
            }
        }
    }

    // dat thong tin khi nhan vao button
    public void GetLevelInformation(string skillName, string description, int stars)
    {
        this.skillName.text = skillName;
        this.description.text = description;
        this.skillStars.text = stars.ToString();
        this.stars = stars;
    }

    // cap nhat so sao con lai len man hinh
    public void UpdateStar()
    {
        starCurrency.text = starSO.starCurrent.ToString();
    }

    // dat dieu kien mua khi bat dau game
    public void InitializeSkillButtons()
    {
        for (int i = 0; i < skillsSO.Length; i++) // Lặp qua từng kỹ năng
        {
            for (int j = 2; j <= skillsSO[i].level; j++) // Duyệt cấp độ từ max về 2
            {
                int index = (5 - j) * 3 + i; // Tính chỉ số nút

                if (index >= 0 && index < skillShopButton.Length) // Kiểm tra chỉ số hợp lệ
                {
                    skillShopButton[index].SetPurchased(true); // Đánh dấu nút đã mua
                    Debug.Log($"Skill: {i}, Level: {j}, Button Index: {index}");
                }
            }
        }
    }

    // nang cap chi so cua skill
    public void UpgradeSkill(int i, float cooldown, int damage, float range)
    {
        skillsSO[i].cooldown += cooldown;
        skillsSO[i].damage += damage;
        skillsSO[i].range += range;
        skillsSO[i].level += 1;
    }

    // button quay lai level select
    public void BackButton()
    {
        SceneManager.LoadScene("Level Select");
        GameManager.Instance.SaveData();
    }
}