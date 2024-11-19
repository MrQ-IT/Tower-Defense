using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillShopButton : MonoBehaviour
{
    [SerializeField] private GameObject Purchased;
    [SerializeField] private SkillShopSO skillShopSO;   



    private void Start()
    {
        if (skillShopSO.isPurchased)
        {
            Purchased.SetActive(true);
        }
        else
        {
            Purchased.SetActive(false);
        }
    }

    // su kien khi nhan vao button ki nang
    public void OnClickButton()
    {
        SkillShop.Instance.GetLevelInformation(skillShopSO.skillName, skillShopSO.description, skillShopSO.star);
    }

    // lay ten cua ki nang
    public string GetSkillName()
    {
        return skillShopSO.skillName;
    }

    // dat giao dien da mua
    public void SetActivePurchased(bool condition)
    {
        Purchased.SetActive(condition);
    }

    // dat kieu kien da mua
    public void SetPurchased(bool condition)
    {
        skillShopSO.isPurchased = condition;
    }

    // lay dieu kien da mua
    public bool GetPurchased()
    {
        return skillShopSO.isPurchased;
    }

    public int GetSkillType()
    {
        return skillShopSO.skillType;
    }

    public int GetStar()
    {
        return skillShopSO.star;
    }
}
