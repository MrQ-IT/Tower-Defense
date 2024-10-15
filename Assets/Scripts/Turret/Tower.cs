using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Animator animator;
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

    private void Initialize()
    {
        animator = GetComponent<Animator>();
    }

    // Animation Event
    private void SetArcherActive()
    {
        archer.SetActive(true);
        animator.SetBool("Idle", true);
    }
}
