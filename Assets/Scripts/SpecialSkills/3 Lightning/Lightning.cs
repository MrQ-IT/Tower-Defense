using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
	public int level = 1;
	public int baseDamage = 150;

	private float duration = 1f; // Short duration for lightning strike
	private int damage;

	void Start()
	{
		damage = baseDamage * level;
		Destroy(gameObject, duration); // Destroy lightning after duration
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Bee>().TakeDamage(damage);
		}
	}
}