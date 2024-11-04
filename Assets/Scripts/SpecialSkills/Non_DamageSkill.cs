using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_DamageSkill : MonoBehaviour
{
	public SkillsSO skillData; // Reference to SkillsSO

	private void Start()
	{

		float skillDuration = skillData.duration;
		Destroy(gameObject, skillDuration);
		// Non-damaging skill logic, e.g., slow effect or barricade properties
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Implement specific non-damaging effects here
	}
}
