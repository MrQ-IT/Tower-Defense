using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : MonoBehaviour
{
    public EnemySO EnemyData;
    public int speed { get; set; }
    public int health { get; set; }
    public int currency { get; set; }
    public string enemyName { get; set; }
    private HealthBar healthBar;
    private GameObject healthBarObject;
    private Animator animator;
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
        health -= damage;
        if (health <= 0)
        {
            SetDeathAnimation();
        }
        healthBar.SetHealth(health);
    }

    public void SetDeathAnimation()
    {
        animator.SetBool("Death", true);
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
    }
}
