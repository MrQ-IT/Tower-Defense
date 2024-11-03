using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
	public SkillsSO skillData;                // Reference to SkillSO
	public GameObject castingCirclePrefab;    // Prefab for the casting circle UI
	public Text cooldownText;                 // Text to display cooldown information

	private GameObject castingCircleInstance;
	private bool isCasting = false;           // Track if we are in casting mode

	void Update()
	{
		// Update cooldown timer in SkillSO
		skillData.UpdateCooldown();

		// Update the cooldown text display
		UpdateCooldownText();

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

	// Called when skill button is clicked
	public void SelectSkill()
	{
		if (!skillData.IsOnCooldown) // Only enable casting if the skill is not on cooldown
		{
			EnableCastingMode();
		}
		else
		{
			Debug.Log($"{skillData.skillName} is on cooldown!");
		}
	}

	private void EnableCastingMode()
	{
		isCasting = true;
		castingCircleInstance = Instantiate(castingCirclePrefab);
	}

	private void CastSkill(Vector3 castPosition)
	{
		if (!skillData.IsOnCooldown) // Check for cooldown before casting
		{
			// Execute the skill and start cooldown
			skillData.ExecuteSkill(castPosition);
			skillData.cooldownTimer = skillData.cooldown;  // Start cooldown timer
		}
		else
		{
			Debug.Log($"{skillData.skillName} is on cooldown!"); // Feedback if trying to cast on cooldown
		}

		CancelCastingMode();  // Exit casting mode after casting
	}

	private void CancelCastingMode()
	{
		isCasting = false;
		if (castingCircleInstance != null)
		{
			Destroy(castingCircleInstance);
		}
	}

	private void UpdateCooldownText()
	{
		// Display cooldown with one decimal place, or clear text if no cooldown
		if (skillData.IsOnCooldown)
		{
			cooldownText.text = $"{skillData.cooldownTimer:F1}";
		}
		else
		{
			cooldownText.text = ""; // Clear text when cooldown is over
		}
	}
}
