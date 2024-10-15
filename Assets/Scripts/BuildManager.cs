using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    private Image[] childGameObject;

    private int selectedTower = 0;
    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        childGameObject = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < childGameObject.Length; i++)
        {
            
        }
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }
}
