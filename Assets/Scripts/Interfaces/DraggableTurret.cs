using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableTurret : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    
    // thử chức năng kéo tháp vào bản đồ chính
    [SerializeField] private GameObject pfTurret;
    private GameObject turretPreview;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        //parentAfterDrag = transform.parent; // lấy vị trí hiện tại của đối tượng trong hierarchy
        //transform.SetParent(transform.root); // set layer thành layer của lớp gốc chứa nó
        //transform.SetAsLastSibling();
        //image.raycastTarget = false;
        
        //
        turretPreview = Instantiate(pfTurret);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        //transform.position = Input.mousePosition;

        // Chuyển đổi từ tọa độ chuột (màn hình) sang tọa độ thế giới (game)
        
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; // Đặt z bằng 0 để đối tượng không bị lệch trên trục z

        GameObject turret = GameObject.Find("Turret_1_Level_1");

        if (mouseWorldPosition.x < turret.transform.position.x + turret.GetComponent<BoxCollider2D>().size.x / 2 &&
            mouseWorldPosition.x > turret.transform.position.x - turret.GetComponent<BoxCollider2D>().size.x / 2 &&
            mouseWorldPosition.y < turret.transform.position.y + turret.GetComponent<BoxCollider2D>().size.y / 2 &&
            mouseWorldPosition.y > turret.transform.position.y - turret.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Debug.Log("OK");
        }
        else
        {
            turretPreview.transform.position = mouseWorldPosition; // Đặt vị trí đối tượng theo tọa độ thế giới
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        //transform.SetParent(parentAfterDrag); // trả đối tượng về vị trí ban đầu trong hierarchy
        //image.raycastTarget = true;
    }

    public void CheckProperPosition()
    {
        
    }

    
}

