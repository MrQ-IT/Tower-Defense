using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int initialCurrency;
    private int currentCurrency;
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
        initialCurrency = 200;
        currentCurrency = initialCurrency;
    }

    public void IncreaseCurrency(int amount)
    {
        currentCurrency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount < currentCurrency)
        {
            currentCurrency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You don't have enough to purchase this item");
            return false;
        }
    }
}
