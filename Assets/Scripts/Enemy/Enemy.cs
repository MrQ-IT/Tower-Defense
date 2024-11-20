using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
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
    public AchievementSO achievementSO;
    private bool isDead;

    private bool isSlowing;
    private Color originalColor; // Lưu màu gốc của kẻ địch
    private Renderer enemyRenderer; // Renderer của đối tượng

    // enemy moves
    public WaypointManager waypointManager;
    private int indexWaypoint;
    private Vector3 direction;

    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        EnemyMoves();
        UpdateHealthBarPos();
    }

    public void Initialize()
    {
        enemyRenderer = GetComponent<Renderer>();
        originalColor = enemyRenderer.material.color; // Lưu màu gốc
        animator = GetComponent<Animator>();
        health = EnemyData.health;
        speed = (int)EnemyData.speed;
        currency = EnemyData.currency;
        enemyName = EnemyData.enemyName;
        SpawnHealthBar();
        healthBar.SetMaxHealth(health);
        isDead = false;

        //waypointManager = GameObject.Find("WayPoints").GetComponent<WaypointManager>();
        indexWaypoint = 0;
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
        InGameManager.main.lastEnemyCount--;
        Debug.Log(InGameManager.main.lastEnemyCount + " " + InGameManager.main.outOfEnemies);
        if (InGameManager.main.outOfEnemies && InGameManager.main.lastEnemyCount == 0)
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

    public void ChangeMovementAnimation()
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

    private void EnemyMoves()
    {
        if (indexWaypoint < waypointManager.wayPoints.Length)
        {
            Transform targetWaypoint = waypointManager.wayPoints[indexWaypoint];
            direction = targetWaypoint.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            ChangeMovementAnimation();
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                indexWaypoint++;
            }
        }
        else
        {
            LivesManager.main.DecreaseLives();
            GetComponent<Enemy>().RemoveOnPathEnd();
        }
    }

    public void ApplySlowEffect()
    {
        enemyRenderer.material.color = new Color(127f / 255f, 189f / 255f, 248f / 255f);
        speed = (int)(speed / 2);
        Debug.Log(speed);
        Invoke("RemoveSlowEffect", 2f);
    }

    public void RemoveSlowEffect()
    {
        enemyRenderer.material.color = originalColor;
        speed = (int)EnemyData.speed;
    }
}
