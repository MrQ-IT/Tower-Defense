using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{   
    public ArcherSO archerSO;
    public int attackRange { get; set; }
    public int turretCost {  get; set; }
    public int damage { get; set; }
    public int attackSpeed { get; set; }
    [SerializeField] private GameObject pfProjectileArrow;
    [SerializeField] private GameObject attackArrow;
    private Animator animator;
    private GameObject[] enemies;
    private GameObject focusBee;
    private GameObject arrow;
    private bool isSelected; // Kiểm tra sự kiện click vào Archer
    private bool isAttack;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        ChangeAnimation();
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
        attackRange = archerSO.range;
        turretCost = archerSO.turretCost;
        damage = archerSO.damage;
        attackSpeed = archerSO.attackSpeed;
        transform.Find("AttackRange").localScale = new Vector3(attackRange*2, attackRange*2, 0);
        // Tắt hình tròn hiện tầm bắn ban đầu
        attackArrow.SetActive(false);
        isSelected = false;
        isAttack = false;
    }

    // Đây là Event Animation
    public void ShootArrow()
    {
        if (focusBee != null && arrow == null)
        {
            // Tạo ra mũi tên và đặt kẻ địch cần bắn cho nó
            arrow = Instantiate(pfProjectileArrow);
            arrow.transform.SetParent(transform, false);
            arrow.transform.position = transform.position;
            arrow.GetComponent<ProjectileArrow>().CheckFocusEnemy(focusBee.GetComponent<Bee>());
            animator.SetBool("Idle", true);
        }
    }
    // Kiểm tra kẻ địch nào ở trong vùng, có thì trả về đối tượng đầu tiên, không thì trả về null
    private GameObject GetEnemyInRange(GameObject[] enemies) 
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, transform.position) <= attackRange)
            {   
                return enemies[i];
            }
        }
        return null;
    }
    
    // Hiện tầm bắn của Archer khi nhấn chuột
    private void OnMouseDown()
    {
        isSelected = !isSelected;
        attackArrow.SetActive(isSelected);
        UIManager.main.transform.Find("TowerInfoManager").gameObject.SetActive(isSelected);
        TowerInfoManager.main.SetArcherSO(this.archerSO);
    }  

    // Thay đổi animation của Archer
    private void ChangeAnimation()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Lấy tất cả các GameObject Bee
        focusBee = GetEnemyInRange(enemies); // Kiểm tra tầm bắn

        if (focusBee != null && !isAttack) // Nếu có đối tượng trong vùng thì chuyển animation
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
            isAttack = true;
            StartCoroutine(AttackCooldown());
        }
        //else
        //{
        //    animator.SetBool("Idle", true);
        //}
        else if ( focusBee == null)
        {
            animator.SetBool("Idle", true);
        }
    }

    private IEnumerator AttackCooldown()
    {
        ChangeAttackAnimation();
        yield return new WaitForSeconds(attackSpeed);
        isAttack = false;
        //animator.SetBool("Idle", true);
    }

    public void ChangeAttackAnimation()
    {
        animator.SetBool("Idle", false);
    }
}
