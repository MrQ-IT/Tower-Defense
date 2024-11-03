using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.VisualElement;

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

    public void EnableBuildManager()
    {
        transform.Find("BuildManager").gameObject.SetActive(true);
        foreach (var turret in transform.GetComponentsInChildren<TurretInShop>())
        {
            turret.SetupTurret(plot);
        }
    }

    public void DisableBuildManager()
    {
        transform.Find("BuildManager").gameObject.SetActive(false);
    }

    public GameObject CreateHealthBar()
    {
        GameObject healthBar = Instantiate(pfHealthBar, transform, false);
        return healthBar;
    }

    public void GameOver()
    {
        transform.Find("GameOver").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        transform.Find("GameWin").gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
