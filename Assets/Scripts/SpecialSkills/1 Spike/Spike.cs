using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	public int baseDamage = 30;   // Damage from SkillSO
	public int level = 1;    // Level from SkillSO

	private float duration = 2f;// Duration in seconds, defined locally
	private int damage;

	void Start()
	{
		// Scale the damage according to the skill level
		damage = baseDamage * level;  // Adjusts damage based on level

		// Destroy the spike object after the duration
		Destroy(gameObject, duration);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Bee>().TakeDamage(damage); // Adjust 'Enemy' if your script has a different name
		}
	}
}
