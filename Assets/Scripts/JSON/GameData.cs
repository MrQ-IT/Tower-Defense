using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int starCurrency;
    public List<SkillUpgradeData> skills = new List<SkillUpgradeData>();
    public List<LevelData> levels = new List<LevelData>();

    public GameData(int starCurrency, List<SkillUpgradeData> skills, List<LevelData> levels)
    {
        this.starCurrency = starCurrency;
        this.skills = skills;
        this.levels = levels;
    }
}
