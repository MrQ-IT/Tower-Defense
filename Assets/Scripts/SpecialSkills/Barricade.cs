using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
	public Sprite horizontalSprite;
	public Sprite frontVerticalSprite;
	public Sprite backVerticalSprite;
	public float duration = 5f;

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		SetDirectionSprite();
		Invoke("DestroyBarricade", duration);
	}

	void SetDirectionSprite()
	{
		if (transform.localScale.x > transform.localScale.y)
		{
			spriteRenderer.sprite = horizontalSprite;
		}
		else
		{
			// Choose front or back vertical sprite based on positioning
			spriteRenderer.sprite = IsFrontPosition() ? frontVerticalSprite : backVerticalSprite;
		}
	}

	bool IsFrontPosition()
	{
		// Customize this check to determine when to use the back vs. front sprite
		return transform.position.y >= 0;  // Example condition: positive Y is front, negative Y is back
	}

	void DestroyBarricade()
	{
		Destroy(gameObject);
	}
}
