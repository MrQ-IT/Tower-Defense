using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour, Enemy
{
    private HealthBar healthBar;
    private float dieHealth = 0;
    [SerializeField] private GameObject healthBarPrefab;
    public int Speed { get; set; }
    public int Health { get; set; }

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
        Health -= damage;
        if (Health <= dieHealth)
        {
            Die();
        }
        healthBar.SetHealth(Health);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void SpawnHealthBar()
    {   
        GameObject healthBarObject = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        healthBarObject.transform.SetParent(transform);
        healthBar = healthBarObject.GetComponentInChildren<HealthBar>();
    }

    private void Initialize()
    {
        Health = 100;
        SpawnHealthBar();
        healthBar.SetMaxHealth(Health);
    }
}
