using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/New Skill")]
public class SkillsSO : ScriptableObject
{
	public string skillName;
	public Sprite skillIcon;
	public GameObject skillPrefab;
	public float cooldown;
	public int damage;
	[Range(1, 4)]
	public int level = 1;
	public float range;
	public float duration;

}
