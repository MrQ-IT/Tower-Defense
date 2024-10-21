using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour, Enemy
{
    public EnemySO EnemyData;
    public int speed { get; set; }
    public int health { get; set; }
    public int currency { get; set; }
    private HealthBar healthBar;
    private GameObject healthBarObject;
    
    private Animator animator;
    private float dieHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarObject != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            healthBarObject.transform.position = screenPosition + new Vector3(0, 10, 0); // Điều chỉnh vị trí nếu cần
        }
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
        animator.SetBool("Death", true);
    }

    // Animation Event
    public void DestroyBee()
    {
        CurrencyManager.main.IncreaseCurrency(currency);
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + ": " + currency);
        Destroy(gameObject);
        Destroy(healthBarObject);
    }

    // Show HealthBar
    public void SpawnHealthBar()
    {
        healthBarObject = UIManager.main.CreateHealthBar();
        healthBar = healthBarObject.GetComponentInChildren<HealthBar>();

    }

    private void Initialize()
    {   
        animator = GetComponent<Animator>();
        health = EnemyData.health;
        speed = (int)EnemyData.speed;
        currency = EnemyData.currency;
        SpawnHealthBar();
        healthBar.SetMaxHealth(health);
    }
}
