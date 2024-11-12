using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    private float projectileArrowSpeed = 10f;
    private Vector3 targetPostion;
    private Vector3 spawnPosition;
    private Enemy focusEnemy;
    private Animator animator;
    private int damage;
    public bool isSlowing;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        ProjectileArrowMoves();
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
        spawnPosition = transform.position;
        damage = GetComponentInParent<Archer>().damage;
    }

    // Truyền bee trong tầm bắn từ Archer vào
    public void CheckFocusEnemy(Enemy enemy)
    {
        focusEnemy = enemy;
        targetPostion = focusEnemy.transform.position;
    }

    private void ProjectileArrowMoves()
    {
        if (focusEnemy == null) // Hủy mũi tên nếu không có kẻ địch phù hợp
        {
            Destroy(gameObject);
            return;
        }
        targetPostion = focusEnemy.transform.position;
        Vector3 direction = (targetPostion - spawnPosition).normalized;
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        transform.Translate(direction * projectileArrowSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            focusEnemy.TakeDamage(damage);
            Destroy(gameObject);
            if (isSlowing)
            {
                focusEnemy.ApplySlowEffect();
            }
        }
    }
}
