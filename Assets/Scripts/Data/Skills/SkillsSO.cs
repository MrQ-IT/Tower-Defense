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
	public int maxCharges;
	public float cooldown;
	public int baseDamage;

	[Range(1, 4)]
	public int skillLevel = 1;

	public int durationInFrames;

	public void ExecuteSkill(Vector3 position)
	{
		// Instantiate the skill's effect at the specified position
		if (skillPrefab != null)
		{
			Instantiate(skillPrefab, position, Quaternion.identity);
		}
	}
}
