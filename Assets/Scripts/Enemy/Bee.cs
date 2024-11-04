using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    public EnemySO EnemyData;
    public int speed { get; set; }
    public int health { get; set; }
    public int currency { get; set; }
    public string enemyName { get; set; }
    private HealthBar healthBar;
    private GameObject healthBarObject;
    private GameObject coinPopupObject;
    private Animator animator;
    private bool isDead;
    public AchievementSO achievementSO;

    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        UpdateHealthBarPos();
    }

    public void Initialize()
    {   
        animator = GetComponent<Animator>();
        health = EnemyData.health;
        speed = (int)EnemyData.speed;
        currency = EnemyData.currency;
        enemyName = EnemyData.enemyName;
        SpawnHealthBar();
        healthBar.SetMaxHealth(health);
        isDead = false;
    }

    // Animation Event
    public void DestroyBee()
    {   
        RemoveOnPathEnd();
        CurrencyManager.main.IncreaseCurrency(currency);
    }

    public void RemoveOnPathEnd()
    {
        Destroy(gameObject);
        Destroy(healthBarObject);
        Destroy(coinPopupObject);
        WaveManager.main.lastEnemyCount--;
        if (WaveManager.main.outOfEnemies && WaveManager.main.lastEnemyCount == 0)
        {
            UIManager.main.GameWin();
        }
    }

    // Show HealthBar
    public void SpawnHealthBar()
    {
        healthBarObject = UIManager.main.CreateHealthBar();
        healthBar = healthBarObject.GetComponentInChildren<HealthBar>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {   
            isDead = true;
            SetDeathAnimation();
        }
    }

    public void SetDeathAnimation()
    {   
        animator.SetBool("Death", true);
        coinPopupObject = UIManager.main.CreateCoinPopup();
        coinPopupObject.transform.GetComponentInChildren<Text>().text = "+" + currency.ToString();
    }

    public void ChangeMovementAnimation(Vector3 direction)
    {
        if (Math.Abs(direction.x) > Math.Abs(direction.y)) // Ưu tiên hướng có giá trị lớn hơn
        {
            direction.x = Mathf.Sign(direction.x);  // Làm tròn về 1 hoặc -1
            direction.y = 0;
        }
        else if (Math.Abs(direction.y) > Math.Abs(direction.x))
        {
            direction.y = Mathf.Sign(direction.y);  // Làm tròn về 1 hoặc -1
            direction.x = 0;
        }
        animator.SetFloat("X", direction.normalized.x);
        animator.SetFloat("Y", direction.normalized.y);
    }

    public void UpdateHealthBarPos()
    {
        if (healthBarObject != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            healthBarObject.transform.position = screenPosition + new Vector3(0, 10, 0);
        }
        if (coinPopupObject != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            coinPopupObject.transform.position = screenPosition + new Vector3(10, 0, 0);
        }
    }
}
