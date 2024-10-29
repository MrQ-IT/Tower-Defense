using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ArcherSO")] 
public class ArcherSO : ScriptableObject
{
    public float range;
    public string towerName;
    public int damage;
    public float attackSpeed;
    public GameObject turretPrefab;
    public int towerCost;
    public string description;
    public Sprite towerSprite;
}
