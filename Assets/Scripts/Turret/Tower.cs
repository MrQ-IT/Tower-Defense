using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Animator animator;
    private float idleNumber;
    public float upgradeNumber;
    [SerializeField] private GameObject archer;
    public Plot plot;

    void Start()
    {
        Initialize();
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
