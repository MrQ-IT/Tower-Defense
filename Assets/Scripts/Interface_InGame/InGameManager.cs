using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private Vector3 dragOrigin;
    [SerializeField] private float dragSpeed = 0.1f;
    public static InGameManager main;
    public int lastEnemyCount = 0;
    public bool outOfEnemies = false;

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.main.transform.Find("GamePause").gameObject.activeSelf == false)
            DragMap();
    }

    public void Initialize()
    {
        main = this;
    }

    private void DragMap()
    {
        // Khi người chơi nhấn chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // Khi người chơi kéo chuột trái
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = Camera.main.transform.position + difference * dragSpeed;

            // Tạo một biến để lưu vị trí cuối cùng sẽ cập nhật
            Vector3 finalPosition = Camera.main.transform.position;

            // Kiểm tra giới hạn cho trục x
            if (newPosition.x >= -7 && newPosition.x <= 17)
            {
                finalPosition.x = newPosition.x;
            }

            // Kiểm tra giới hạn cho trục y
            if (newPosition.y >= -8 && newPosition.y <= 6)
            {
                finalPosition.y = newPosition.y;
            }

            // Cập nhật vị trí camera
            Camera.main.transform.position = finalPosition;
        }
    }
}
