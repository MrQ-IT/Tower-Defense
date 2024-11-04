using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : MonoBehaviour
{
	public SkillsSO skillData; // Reference to SkillsSO

	private void Start()
	{
		int calculatedDamage = skillData.damage * skillData.level;
		float skillDuration = skillData.duration;
		Destroy(gameObject, skillDuration);

		// Set damage-related properties in the specific skill script
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			Bee enemy = other.GetComponent<Bee>();
			if (enemy != null)
			{
				enemy.TakeDamage(skillData.damage * skillData.level);
			}
		}
	}
}
