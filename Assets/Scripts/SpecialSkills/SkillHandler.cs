using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
	public SkillsSO skillData;            // Reference to SkillSO
	public GameObject castingCirclePrefab;  // Prefab for the casting circle UI
	public Text chargeText;

	private GameObject castingCircleInstance;
	private bool isCasting = false;      // Track if we are in casting mode
	private int currentCharges;

	void Start()
	{
		currentCharges = skillData.maxCharges;
		UpdateChargeText();
	}

	// Called when skill button is clicked
	public void SelectSkill()
	{
		if (currentCharges > 0)
		{
			EnableCastingMode();
		}
	}

	void Update()
	{
		// Only update casting circle position if we're in casting mode
		if (isCasting && castingCircleInstance != null)
		{
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cursorPosition.z = 0f;
			castingCircleInstance.transform.position = cursorPosition;

			// Check for the cast trigger with left mouse button click
			if (Input.GetMouseButtonDown(0))
			{
				CastSkill(cursorPosition);
			}
			else if (Input.GetMouseButtonDown(1))  // Right-click cancels casting
			{
				CancelCastingMode();
			}
		}
	}

	private void EnableCastingMode()
	{
		isCasting = true;
		castingCircleInstance = Instantiate(castingCirclePrefab);
	}

	private void CastSkill(Vector3 castPosition)
	{
		if (currentCharges > 0)
		{
			GameObject skillInstance = Instantiate(skillData.skillPrefab, castPosition, Quaternion.identity);
			ApplySkillProperties(skillInstance);
			currentCharges--;
			UpdateChargeText();
		}

		CancelCastingMode();  // Exit casting mode after casting
	}

	private void ApplySkillProperties(GameObject skillInstance)
	{
		Spike spikeScript = skillInstance.GetComponent<Spike>();
		if (spikeScript != null)
		{
			spikeScript.damage = skillData.baseDamage * skillData.skillLevel;
			spikeScript.durationInFrames = skillData.durationInFrames;
		}
	}

	private void CancelCastingMode()
	{
		isCasting = false;
		if (castingCircleInstance != null)
		{
			Destroy(castingCircleInstance);
		}
	}

	private void UpdateChargeText()
	{
		chargeText.text = $"x{currentCharges}";
	}
}
