using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SkillShopSO")]
public class SkillShopSO : ScriptableObject
{    
    public bool isPurchased = false;
    public string description;
    public int star;
    public string skillName;
    public int skillType;
}