using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StarSkillSO")]
public class StarSkill : ScriptableObject
{    
    public bool isPurchased = false;
    public Color purchasedColor = new Color(0, 0, 0, 0.5f);
}