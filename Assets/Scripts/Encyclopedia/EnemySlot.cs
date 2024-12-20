using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlot : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private Image enemyImage;
    [SerializeField] private Text enemyName;
    [SerializeField] private Text health;
    [SerializeField] private Text speed;
    [SerializeField] private Text gold;

    private void Start()
    {
        enemyImage.sprite = enemySO.enemySprite;
        enemyName.text = enemySO.enemyName;
        health.text = enemySO.health.ToString();
        speed.text = enemySO.speed.ToString();
        gold.text = enemySO.currency.ToString();
    }
}
