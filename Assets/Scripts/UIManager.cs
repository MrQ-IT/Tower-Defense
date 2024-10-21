using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager main;
    public Plot plot { get; set; }
    [SerializeField] private GameObject pfHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableBuildManager()
    {
        transform.Find("BuildManager").gameObject.SetActive(true);
        foreach (var turret in transform.GetComponentsInChildren<TurretInShop>())
        {   
            Debug.Log(plot);
            turret.SetupTurret(plot);
        }

    }

    public void DisableBuildManager()
    {
        transform.Find("BuildManager").gameObject.SetActive(false);
    }

    public GameObject CreateHealthBar()
    {
        GameObject healthBar = Instantiate(pfHealthBar); // Tạo đối tượng mà không chỉ định parent
        healthBar.transform.SetParent(transform, false); // Đặt parent là UI Manager, nếu cần
        return healthBar;
    }
}
