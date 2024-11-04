using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	[HideInInspector] public int damage;           // Damage calculated by SkillDragHandler
	[HideInInspector] public int durationInFrames; // Duration in frames from SkillSO

	private float durationInSeconds;

	void Start()
	{
		// Convert frames to seconds based on a typical frame rate (e.g., 60 FPS)
		float framesPerSecond = 10f; // Adjust this value if your game has a different FPS
		durationInSeconds = durationInFrames / framesPerSecond;

		// Destroy the spike object after the calculated duration
		Destroy(gameObject, durationInSeconds);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Bee>().TakeDamage(damage);
		}
	}
}
