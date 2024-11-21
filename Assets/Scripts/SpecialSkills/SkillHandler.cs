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
    [SerializeField] Image lockImage;
    private GameObject castingCircleInstance;
    private bool isCasting = false;        // Track if we are in casting mode
    private float cooldownTimer = 0f;
    public AchievementSO achievementSO;

    private void Start()
    {
        cooldownTimer = 0f;
        isCasting = false ;
        lockImage.gameObject.SetActive(skillData.islock);
    }

    void Update()
    {
        UpdateCooldown();

        // Display the cooldown timer
        DisplayCooldown();

        // Only update casting circle position if we're in casting mode
        SpawnCastingCircle();
    }

    public void SpawnCastingCircle()
    {
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

    public void DisplayCooldown()
    {
        if (IsOnCooldown())
        {
            cooldownText.text = $"{cooldownTimer:F1}"; // Format timer to one decimal
        }
        else
        {
            cooldownText.text = ""; // Clear the text when not on cooldown
        }
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
            if (skillData.skillName == "Lightning")
            {
                position.y += 2f;
                Instantiate(skillData.skillPrefab, position, Quaternion.identity);
                Debug.Log(skillData.skillPrefab.GetComponent<CircleCollider2D>().radius);
            }
            else
            {
                Instantiate(skillData.skillPrefab, position, Quaternion.identity);
            }
            achievementSO.useSkill += 1;
            StartCooldown(); // Start cooldown after executing the skill
            CancelCastingMode();
        }
    }

    // Button Event
    public void SelectSkill()
    {
        if (!IsOnCooldown() && !skillData.islock) // Only enable casting if the skill is not on cooldown
        {
            isCasting = true;
            castingCircleInstance = Instantiate(castingCirclePrefab);
            castingCircleInstance.transform.localScale = Vector3.one * skillData.range;
            skillData.skillPrefab.GetComponent<CircleCollider2D>().radius = skillData.range;
        }
        else
        {
            Debug.Log($"{skillData.skillName} is on cooldown!");
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
}
