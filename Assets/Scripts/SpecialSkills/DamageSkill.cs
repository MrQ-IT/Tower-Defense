using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : MonoBehaviour
{
	public SkillsSO skillData; // Reference to SkillsSO

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
        int calculatedDamage = skillData.damage * skillData.level;
        float skillDuration = skillData.duration;
        Destroy(gameObject, skillDuration);
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
