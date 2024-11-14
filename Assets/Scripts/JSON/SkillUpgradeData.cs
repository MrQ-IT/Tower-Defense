using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillUpgradeData
{
    public string skillName;
    public float cooldown;
    public int damage;
    public int level;
    public float range;

    public SkillUpgradeData(string skillName, float cooldown, int damage, int level, float range)
    {
        this.skillName = skillName;
        this.cooldown = cooldown;
        this.damage = damage;
        this.level = level;
        this.range = range;
    }
}
