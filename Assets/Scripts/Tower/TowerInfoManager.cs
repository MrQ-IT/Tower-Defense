using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoManager : MonoBehaviour
{
    public static TowerInfoManager main;
    private Archer archer;   
    private Tower tower;
    private Image sprite;
    private Text towerName;
    private Text towerDescription;
    private Text range;
    private Text damage;
    private Text attackSpeed;
    private Text upgradeCost;
    private Text sellCost;
    private Plot plot;
    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        main = this;
        sprite = transform.Find("Sprite").GetComponent<Image>();
        towerName = transform.Find("Name").GetComponent<Text>();
        towerDescription = transform.Find("Description").GetComponent<Text>();
        range = transform.Find("Range").GetComponent<Text>();
        damage = transform.Find("Damage").GetComponent<Text>();
        attackSpeed = transform.Find("AttackSpeed").GetComponent<Text>();
        upgradeCost = transform.Find("Upgrade").GetComponentInChildren<Text>();
        sellCost = transform.Find("Sell").GetComponentInChildren<Text>();
    }

    public void SetArcherSO(Archer archer, Tower tower)
    {
        this.archer = archer;
        this.tower = tower;
        UpdateTowerInfoManager();
    }

    public void UpdateTowerInfoManager()
    {
        sprite.sprite = archer.towerSprite;
        towerName.text = archer.towerName + " Level " + tower.upgradeNumber;
        towerDescription.text = "Description: " + archer.description;
        range.text = "Range: " + archer.attackRange.ToString();
        damage.text = "Damage: " + archer.damage.ToString();
        attackSpeed.text = "Attack Speed: " + archer.attackSpeed.ToString();
        upgradeCost.text = RoundToTen( archer.towerCost * 0.5 ).ToString();
        sellCost.text = RoundToTen(archer.towerCost * 0.5).ToString();
    }

    // Button Event
    public void Upgrade()
    {
        if (tower.upgradeNumber < 5)
        {
            if ( !CurrencyManager.main.SpendCurrency(RoundToTen(archer.towerCost * 0.5)))
            {
                return;
            }
            archer.damage = archer.damage + (int)(archer.damage * 0.2);
            archer.attackRange += 0.25f;
            archer.range.transform.localScale = new Vector3(archer.attackRange * 2, archer.attackRange * 2, 0);
            archer.towerCost = archer.towerCost + RoundToTen(archer.towerCost * 0.5);
            archer.isAttack = false;
            tower.UpgradeTower();
            
            archer.transform.localPosition = new Vector3(0, (float)(archer.transform.localPosition.y + 0.5), 0);
            if (tower.upgradeNumber >= 4)
            {
                archer.transform.localPosition = new Vector3(0, 1.5f, 0);
            }
            UpdateTowerInfoManager();
        }
        else
        {
            Debug.Log("Tower is max level");
        }
    }

    public void Sell()
    {
        UIManager.main.isTowerSelected = false;
        CurrencyManager.main.IncreaseCurrency(RoundToTen(archer.towerCost * 0.5));
        plot.checkTurret = false;
        Destroy(plot.transform.GetChild(0).gameObject);
        gameObject.SetActive(false);
    }

    public int RoundToTen(double value)
    {
        return (int)(value / 10.0) * 10;
    }

    public void SetPlot(Plot plot)
    {
        this.plot = plot;
    }
}
