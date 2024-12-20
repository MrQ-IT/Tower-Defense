using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    [SerializeField] private ArcherSO archerSO;
    [SerializeField] private Text towerName;
    [SerializeField] private Image image;
    [SerializeField] private Text description;
    [SerializeField] private Text damage;
    [SerializeField] private Text range;
    [SerializeField] private Text reload;
    [SerializeField] private Text currency;

    private void Start()
    { 
        towerName.text = archerSO.towerName;
        image.sprite = archerSO.towerSprite;
        description.text = archerSO.description;
        damage.text = archerSO.damage.ToString();
        range.text = archerSO.range.ToString();
        reload.text = archerSO.attackSpeed.ToString();
        currency.text = archerSO.towerCost.ToString();
    }


}
