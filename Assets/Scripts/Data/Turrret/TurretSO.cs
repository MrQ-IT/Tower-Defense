using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret")]
public class TurretSO : ScriptableObject
{
    public GameObject turretPrefab;
    public int turretCost;
    public Sprite turretSprite;
}
