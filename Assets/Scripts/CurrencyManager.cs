using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    private int initialCurrency;
    private int currentCurrency;
    private Text currencyText;
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
        currencyText = GetComponentInChildren<Text>();
        currencyText.text = initialCurrency.ToString();
    }

    public void IncreaseCurrency(int amount)
    {
        currentCurrency += amount;
        Debug.Log(currencyText);
        currencyText.text = currentCurrency.ToString();
    }

    public bool SpendCurrency(int amount)
    {
        if (amount < currentCurrency)
        {
            currentCurrency -= amount;
            currencyText.text = currentCurrency.ToString();
            return true;
        }
        else
        {
            Debug.Log("You don't have enough to purchase this item");
            return false;
        }
    }
}
