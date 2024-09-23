using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreSlot : MonoBehaviour, IDropHandler
{   
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) // đếm số đối tượng con trong ô
        {
            GameObject dropped = eventData.pointerDrag; // Lấy đối tượng pointerDrag, là đối tượng đang được kéo và thả
            DraggableTurret draggableTurret = dropped.GetComponent<DraggableTurret>();
            draggableTurret.parentAfterDrag = transform;
        }
    }
}
