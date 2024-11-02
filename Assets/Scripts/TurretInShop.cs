using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInShop : MonoBehaviour
{
    public ArcherSO archerSO;
    public GameObject turretPrefab { get; set; }
    public int turretCost { get; set; }
    public Sprite turretSprite { get; set; }
    private Plot plot;
    [SerializeField] private GameObject buildManager;
    public AchievementSO achievementSO;



    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        turretCost = archerSO.towerCost;
        turretSprite = archerSO.towerSprite;
        turretPrefab = archerSO.turretPrefab;

        Image[] image = GetComponentsInChildren<Image>();
        image[1].sprite = turretSprite;
        GetComponentInChildren<Text>().text = turretCost.ToString();;
    }

    public void SetupTurret(Plot plot)
    {
        this.plot = plot;
    }

    // Button Event
    public void BuildTurret()
    {
        if ( plot.checkTurret == false && plot != null && CurrencyManager.main.SpendCurrency(turretCost))
        {
            GameObject tower = Instantiate(turretPrefab, plot.transform.position, Quaternion.identity);
            tower.transform.parent = plot.transform;
            Debug.Log(tower.transform.GetComponentInChildren<Tower>());
            tower.transform.GetComponentInChildren<Tower>().plot = plot;
            buildManager.SetActive(false);
            plot.checkTurret = true;
            achievementSO.value = achievementSO.value + 1;
        }
        else
        {
            Debug.Log("Can not place tower");
        }
    }
}
