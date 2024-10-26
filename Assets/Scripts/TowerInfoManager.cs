using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoManager : MonoBehaviour
{
    public static TowerInfoManager main;
    [SerializeField] private ArcherSO archerSO;   
    
    private Image sprite;
    private Text towerName;
    private Text towerDescription;
    private Text range;
    private Text damage;
    private Text attackSpeed;
    private Text upgradeCost;
    private Text sellCost;

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

    public void SetArcherSO(ArcherSO archerSO)
    {
        this.archerSO = archerSO;
        UpdateTowerInfoManager();
    }

    public void UpdateTowerInfoManager()
    {
        sprite.sprite = archerSO.turretSprite;
        towerName.text = archerSO.towerName;
        towerDescription.text = "Description: " + archerSO.description;
        range.text = "Range: " + archerSO.range.ToString();
        damage.text = "Damage: " + archerSO.damage.ToString();
        attackSpeed.text = "Attack Speed: " + archerSO.attackSpeed.ToString();
        upgradeCost.text = archerSO.upgradeCost.ToString();
        sellCost.text = archerSO.sellCost.ToString();
    }
}
