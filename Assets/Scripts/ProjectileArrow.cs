using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    // khai bao bien
    private float projectileArrowSpeed = 7.0f;
    private Vector3 targetPostion;
    private Vector3 spawnPosition;
    private Bee focusBee;

    // Start is called before the first frame update

    void Start()
    {   
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileArrowMoves();
        BeeTakeDamage();
    }
    
    // Truyền bee trong tầm bắn từ Archer vào
    public void CheckFocusEnemy(Bee bee)
    {
        focusBee = bee;
        targetPostion = focusBee.transform.position;
    }
    private void ProjectileArrowMoves()
    {
        if (focusBee == null) // Hủy mũi tên nếu không có kẻ địch phù hợp
        {
            Destroy(gameObject);
            return;
        }
        targetPostion = focusBee.transform.position; // Cập nhật vị trí kẻ địch liên tục để mũi tên đuổi theo
        Vector3 direction = (targetPostion - spawnPosition).normalized; // Hướng mũi tên di chuyển
        transform.position += direction * projectileArrowSpeed * Time.deltaTime; // Di chuyển mũi tên

    }
    private void BeeTakeDamage()
    {
        if (Vector3.Distance(transform.position, targetPostion) < 1.5f && focusBee != null)
        {
            focusBee.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
