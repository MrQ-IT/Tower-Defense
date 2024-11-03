using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
	public float duration = 5f;
	public float slowFactor = 0.25f;// Factor to reduce enemy speed (e.g., 0.5 means 50% slower)
	public int level = 1;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		Destroy(gameObject, duration);
	}

	/*
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			Bee enemy = other.GetComponent<Bee>();
			if (enemy != null)
			{
				enemy.ApplySlow(slowFactor); // Apply slow effect
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			Bee enemy = other.GetComponent<Bee>();
			if (enemy != null)
			{
				enemy.RemoveSlow(); // Remove slow effect
			}
		}
	}*/
}
