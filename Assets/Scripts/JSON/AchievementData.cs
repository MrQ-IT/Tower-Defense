using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AchievementData
{
    public int kills; // tinh so kill tieu diet duoc ( Kill and Kills )
    public int builds; // so thap xay dung duoc ( build and Builds )
    public int useSkill; // dem so lan su dung ki nang ( Bzonze Cup and Gold Cup )
    public bool starsEarned; // so sao kiem duoc ( Bzonze Star and Gold Star )
    public bool normalSkill; // tat ca ki nang dat level 2
    public bool hardSkill; // tat ca ki nang dat level 3
    public int defense; // hoan thanh man dau tien khong mat mau

    public AchievementData(int kills, int builds, int useSkill, bool starsEarned, bool normalSkill, bool hardSkill, int defense)
    {
        this.kills = kills;
        this.builds = builds;
        this.useSkill = useSkill;
        this.starsEarned = starsEarned;
        this.normalSkill = normalSkill;
        this.hardSkill = hardSkill;
        this.defense = defense;
    }
}
