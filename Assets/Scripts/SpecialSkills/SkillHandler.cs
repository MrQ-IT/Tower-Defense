using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
	public SkillsSO skillData;             // Reference to SkillsSO
	public GameObject castingCirclePrefab; // Prefab for the casting circle UI
	public Text cooldownText;              // Text to display cooldown information

	private GameObject castingCircleInstance;
	private bool isCasting = false;        // Track if we are in casting mode
	private float cooldownTimer = 0f;

	// Static reference to the currently selected SkillHandler
	private static SkillHandler currentSkillHandler;

	void Update()
	{
		UpdateCooldown();

		// Display the cooldown timer
		if (IsOnCooldown())
		{
			cooldownText.text = $"{cooldownTimer:F1}"; // Format timer to one decimal
		}
		else
		{
			cooldownText.text = ""; // Clear the text when not on cooldown
		}

		// Only update casting circle position if we're in casting mode
		if (isCasting && castingCircleInstance != null)
		{
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cursorPosition.z = 0f;
			castingCircleInstance.transform.position = cursorPosition;

			// Check for the cast trigger with left mouse button click
			if (Input.GetMouseButtonDown(0))
			{
				ExecuteSkill(cursorPosition);
			}
			else if (Input.GetMouseButtonDown(1))  // Right-click cancels casting
			{
				CancelCastingMode();
			}
		}
	}

	// Determines if the skill is currently on cooldown
	public bool IsOnCooldown()
	{
		return cooldownTimer > 0;
	}

	// Starts the cooldown for the skill
	public void StartCooldown()
	{
		cooldownTimer = skillData.cooldown;
	}

	// Updates the cooldown timer each frame
	private void UpdateCooldown()
	{
		if (cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0) cooldownTimer = 0;
		}
	}

	// Executes the skill if not on cooldown and starts the cooldown timer
	public void ExecuteSkill(Vector3 position)
	{
		if (skillData.skillPrefab != null && !IsOnCooldown())
		{
			Instantiate(skillData.skillPrefab, position, Quaternion.identity);
			StartCooldown(); // Start cooldown after executing the skill
		}
	}

	// Called when skill button is clicked
	public void SelectSkill()
	{
		if (!IsOnCooldown()) // Only enable casting if the skill is not on cooldown
		{
			// Deselect the current skill if one is already selected
			if (currentSkillHandler != null && currentSkillHandler != this)
			{
				currentSkillHandler.CancelCastingMode();
			}

			// Set this skill as the active one
			currentSkillHandler = this;
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

	private void CancelCastingMode()
	{
		isCasting = false;
		if (castingCircleInstance != null)
		{
			Destroy(castingCircleInstance);
		}

		// Clear the current skill reference if this skill was the active one
		if (currentSkillHandler == this)
		{
			currentSkillHandler = null;
		}
	}
}
