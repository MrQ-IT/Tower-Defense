using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ArcherSO")] 
public class ArcherSO : ScriptableObject
{
    public int range;
    public string towerName;
    public int damage;
    public int attackSpeed;
    public GameObject turretPrefab;
    public int turretCost;
    public int upgradeCost;
    public int sellCost;
    public string description;
    public Sprite turretSprite;
}
