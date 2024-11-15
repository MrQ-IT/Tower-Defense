using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AchievementSO")]
public class AchievementSO : ScriptableObject
{
    public int value; 
    public int normalCondition;
    public int hardCondition;
}
