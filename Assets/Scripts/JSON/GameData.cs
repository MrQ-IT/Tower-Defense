using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int level;
    public int lives;
    public int inGameCurrency;
    public int starCurrency;
    public List<SkillUpgradeData> skills = new List<SkillUpgradeData>();

    public GameData(int level, int lives, int inGameCurrency, int starCurrency, List<SkillUpgradeData> skills)
    {
        this.level = level;
        this.lives = lives;
        this.inGameCurrency = inGameCurrency;
        this.starCurrency = starCurrency;
        this.skills = skills;
    }
}
