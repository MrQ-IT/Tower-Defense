using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/New Skill")]
public class SkillsSO : ScriptableObject
{
	public enum SkillType { Spike, Lightning, Barrel, Barricade }
	public SkillType skillType;

	public string skillName;
	public Sprite skillIcon;
	public GameObject skillPrefab;
	public float cooldown;
	public int baseDamage;

	[Range(1, 4)]
	public int skillLevel = 1;

	[HideInInspector] public float cooldownTimer;

	public bool IsOnCooldown => cooldownTimer > 0;

	public void StartCooldown()
	{
		cooldownTimer = cooldown;
	}

	public void UpdateCooldown()
	{
		if (cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0) cooldownTimer = 0;
		}
	}

	public void ExecuteSkill(Vector3 position)
	{
		if (skillPrefab != null && !IsOnCooldown)
		{
			Instantiate(skillPrefab, position, Quaternion.identity);
			StartCooldown(); // Start cooldown after executing the skill
		}
	}
}
