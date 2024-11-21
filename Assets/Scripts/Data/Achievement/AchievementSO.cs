using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AchievementSO")]
public class AchievementSO : ScriptableObject
{
    public int kills; // tinh so kill tieu diet duoc ( Kill and Kills )
    public int builds; // so thap xay dung duoc ( build and Builds )
    public int useSkill; // dem so lan su dung ki nang ( Bzonze Cup and Gold Cup )
    public int starsEarned; // so sao kiem duoc ( Bzonze Star and Gold Star )
    public bool normalSkill; // tat ca ki nang dat level 2
    public bool hardSkill; // tat ca ki nang dat level 3
    public bool defense; // hoan thanh man dau tien khong mat mau
}
