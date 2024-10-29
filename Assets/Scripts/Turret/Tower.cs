using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Animator animator;
    private float idleNumber;
    public float upgradeNumber { get; set; }
    [SerializeField] private GameObject archer;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        idleNumber = 1;
        upgradeNumber = 1;
        animator.SetFloat("Upgrade", upgradeNumber);
        animator.SetBool("IsIdle", false);
    }

    // Animation Event
    public void SetArcherActive()
    {
        archer.SetActive(true);
        animator.SetFloat("Idle", idleNumber);
        animator.SetBool("IsIdle", true);
    }

    public void UpgradeTower()
    {
        archer.SetActive(false);
        idleNumber += 1;
        upgradeNumber += 1;
        animator.SetFloat("Upgrade", upgradeNumber);
        animator.SetBool("IsIdle", false);
    }
}
