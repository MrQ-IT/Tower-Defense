using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpikeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public GameObject spikePrefab;       // Spike prefab to instantiate
	public GameObject targetCursorPrefab; // Targeting cursor prefab
	public int spikeCharges = 3;         // Initial spike charges
	public Text chargeText;

    private GameObject targetCursorInstance;
    private bool isDragging = false;

	// Start is called before the first frame update
	void Start()
    {
        UpdateChargeText();
    }

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (spikeCharges <= 0) return;

		// Start dragging and instantiate the targeting cursor
		isDragging = true;
		targetCursorInstance = Instantiate(targetCursorPrefab);
	}


	public void OnDrag(PointerEventData eventData)
	{
		if (isDragging)
		{
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			cursorPosition.z = 0f;
			targetCursorInstance.transform.position = cursorPosition;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (isDragging && spikeCharges > 0)
		{
			Vector3 castPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			castPosition.z = 0f;
			CastSpike(castPosition);
			spikeCharges--;
			UpdateChargeText();
		}

		isDragging = false;
		Destroy(targetCursorInstance);
	}

	void CastSpike(Vector3 position)
	{
		Instantiate(spikePrefab, position, Quaternion.identity);
	}

	void UpdateChargeText()
	{
		chargeText.text = $"x{spikeCharges}";
	}

	public void AddCharge(int amount)
	{
		spikeCharges += amount;
		UpdateChargeText();
	}

}
