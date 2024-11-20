using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int starCurrency;
    public AchievementData achievement;
    public List<SkillUpgradeData> skills = new List<SkillUpgradeData>();
    public List<LevelData> levels = new List<LevelData>();

    public GameData(int starCurrency, AchievementData achievement, List<SkillUpgradeData> skills, List<LevelData> levels)
    {
        this.starCurrency = starCurrency;
        this.achievement = achievement;
        this.skills = skills;
        this.levels = levels;
    }
}
