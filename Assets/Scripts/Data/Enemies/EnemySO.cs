using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/New Enemy Data")]
public class EnemySO : ScriptableObject
{
    public float speed;
    public int health;
    public int currency;
    public string enemyName;
    public Sprite enemySprite;
}
