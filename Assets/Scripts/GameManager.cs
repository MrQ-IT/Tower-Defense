using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health;
    private Vector3 dragOrigin;
    [SerializeField] private float dragSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DragMap();
    }

    private void Initialize()
    {
        health = 20;
    }

    private void LoseHealth()
    {
        if (health > 0)
        {
            health -= 1;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
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
            if (newPosition.x >= -1 && newPosition.x <= 11)
            {
                finalPosition.x = newPosition.x;
            }

            // Kiểm tra giới hạn cho trục y
            if (newPosition.y >= -7 && newPosition.y <= 5)
            {
                finalPosition.y = newPosition.y;
            }

            // Cập nhật vị trí camera
            Camera.main.transform.position = finalPosition;
        }
    }
}
