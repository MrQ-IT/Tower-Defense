﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UIElements.VisualElement;

public class UIManager : MonoBehaviour
{
    public static UIManager main;
    public bool isTowerSelected;
    public bool isPlotSelected;
    public Plot plot { get; set; }
    [SerializeField] private GameObject pfHealthBar;
    [SerializeField] private GameObject pfCoinPopup;

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

    public GameObject CreateCoinPopup()
    {
        GameObject coinPopup = Instantiate(pfCoinPopup, transform, false);
        return coinPopup;
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

    // button event
    public void Option()
    {
        transform.Find("GamePause").gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButton()
    {
        transform.Find("GamePause").gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // cac su kien cua button
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.SaveData();
        Time.timeScale = 1;
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        int index = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.SaveData();
        SceneManager.LoadScene(index);
    }

    public void NextButton()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index == 11) return;
        GameManager.Instance.SaveData();
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
}
