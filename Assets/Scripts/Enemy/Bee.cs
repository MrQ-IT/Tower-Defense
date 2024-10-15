using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour, Enemy
{
    public EnemySO EnemyData;

    private HealthBar healthBar;
    private float dieHealth = 0;
    [SerializeField] private GameObject healthBarPrefab;
    public int speed { get; set; }
    public int health { get; set; }
    public int currency { get; set; }

    // Thử chức năng tiền
    [SerializeField] private CurrencyManager currencyManager;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= dieHealth)
        {
            Die();
        }
        healthBar.SetHealth(health);
    }

    public void Die()
    {   
        currencyManager.IncreaseCurrency(currency);
        Destroy(gameObject);
    }

    // Show HealthBar
    public void SpawnHealthBar()
    {   
        GameObject healthBarObject = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        healthBarObject.transform.SetParent(transform);
        healthBar = healthBarObject.GetComponentInChildren<HealthBar>();
    }

    private void Initialize()
    {
        health = EnemyData.health;
        speed = (int)EnemyData.speed;
        currency = EnemyData.currency;
        SpawnHealthBar();
        healthBar.SetMaxHealth(health);
    }
}
