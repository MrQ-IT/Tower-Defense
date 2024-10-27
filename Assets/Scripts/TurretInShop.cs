using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretInShop : MonoBehaviour
{
    public TurretSO turretSO;
    public GameObject turretPrefab { get; set; }
    public int turretCost { get; set; }
    public Sprite turretSprite { get; set; }
    private Plot plot;

    [SerializeField] private GameObject buildManager;

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
        turretCost = turretSO.turretCost;
        turretSprite = turretSO.turretSprite;
        turretPrefab = turretSO.turretPrefab;

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
        if ( plot.checkTurret == false && plot != null)
        {
            Instantiate(turretPrefab, plot.transform.position, Quaternion.identity);
            buildManager.SetActive(false);
            plot.checkTurret = true;
        }
        else
        {
            Debug.Log("Can not place tower");
        }
    }
}
