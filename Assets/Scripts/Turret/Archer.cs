using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{   
    public ArcherSO archerSO;
    public int attackRange { get; set; }
    [SerializeField] private GameObject pfProjectileArrow;
    [SerializeField] private GameObject attackArrow;
    private Animator animator;
    private GameObject[] Bees;
    private GameObject focusBee;
    private GameObject arrow;
    private bool isSelected; // Kiểm tra sự kiện click vào Archer
    
    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeAnimation();
    }

    // Khởi tạo
    private void Initialize()
    {
        attackRange = archerSO.attackRange;
        animator = GetComponent<Animator>();
        // Tắt hình tròn hiện tầm bắn ban đầu
        attackArrow.SetActive(false);
        isSelected = false;
    }

    // Đây là Event Animation
    public void ShootArrow()
    {
        if (focusBee != null && arrow == null)
        {   
            // Tạo ra mũi tên và đặt kẻ địch cần bắn cho nó
            arrow = Instantiate(pfProjectileArrow, transform.position, Quaternion.identity);
            arrow.GetComponent<ProjectileArrow>().CheckFocusEnemy(focusBee.GetComponent<Bee>());
        }
    }

    // Vẽ tầm bắn trong Scene View khi nhấn nào Archer
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Kiểm tra kẻ địch nào ở trong vùng, có thì trả về đối tượng đầu tiên, không thì trả về null
    private GameObject GetEnemyInRange(GameObject[] Bees) 
    {
        for (int i = 0; i < Bees.Length; i++)
        {
            if (Vector3.Distance(Bees[i].transform.position, transform.position) <= attackRange)
            {   
                return Bees[i];
            }
        }
        return null;
    }
    
    // Hiện tầm bắn của Archer khi nhấn chuột
    private void OnMouseDown()
    {
        isSelected = !isSelected;
        attackArrow.SetActive(isSelected);
    }  

    // Thay đổi animation của Archer
    private void ChangeAnimation()
    {
        Bees = GameObject.FindGameObjectsWithTag("Bee"); // Lấy tất cả các GameObject Bee
        focusBee = GetEnemyInRange(Bees); // Kiểm tra tầm bắn

        if (focusBee != null ) // Nếu có đối tượng trong vùng thì chuyển animation
        {
            Vector3 dir = (focusBee.transform.position - transform.position).normalized; // Cập nhật hướng đối tượng liên tục
            if (Math.Abs(dir.x) > Math.Abs(dir.y)) // Ưu tiên hướng có giá trị lớn hơn
            {
                dir.x = Mathf.Sign(dir.x);  // Làm tròn về 1 hoặc -1
                dir.y = 0;
            }
            else if (Math.Abs(dir.y) > Math.Abs(dir.x))
            {
                dir.y = Mathf.Sign(dir.y);  // Làm tròn về 1 hoặc -1
                dir.x = 0;
            }
            animator.SetFloat("X", dir.x);
            animator.SetFloat("Y", dir.y); 
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }
}
