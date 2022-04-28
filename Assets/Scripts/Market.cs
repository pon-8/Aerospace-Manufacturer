using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Market : MonoBehaviour
{
    //needed variables for market
    public GameObject sellError;
    public static Market instance;
    public Button sellButton;
    public Button marketButton;
    public TextMeshProUGUI stockText;
    private Factory factoryObject;
    private Money moneyObject;
    private int sellAmount = 1;
    public TMP_InputField setAmount;
    public int sellPrice;

    // Start is called before the first frame update
    void Start()
    {
        // creating instance
        if (instance == null)
        {
            instance = this;
        }

        // creating a component of the factory for the market script to call stock amount
        factoryObject = GetComponent<Factory>();
        moneyObject = GetComponent<Money>();

        // getting button components
        Button sbtn = sellButton.GetComponent<Button>();
        Button mbtn = marketButton.GetComponent<Button>();

        TMP_InputField setA = setAmount.GetComponent<TMP_InputField>();

        // creating button listeners
        sbtn.onClick.AddListener(SellOnClick);
        mbtn.onClick.AddListener(UpdateOnClick);

        // updating stock to Stock Amount text object
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);

        sellPrice = 6;

        // disabling sellButton if stock less than 1
        if (factoryObject.stock < 1)
        {
            sellButton.enabled = false;
        }
    }

    // objects to update when market UI is entered
    void UpdateOnClick()
    {
        // stock update
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);
        
        // enable sellButton if stock more than 0
        if (factoryObject.stock > 0)
        {
            sellButton.enabled = true;
        }
    }

    // actions when sellButton is pressed
    void SellOnClick()
    {
        
        if (setAmount.GetComponentInChildren<TMP_InputField>().text.Length > 0)
        {
            string sellAContent = setAmount.GetComponentInChildren<TMP_InputField>().text;
            sellAmount = Convert.ToInt32(sellAContent);
        } else
        {
            sellAmount = 1;
        }

        if (sellAmount <= factoryObject.stock)
        {
            sellError.SetActive(false);
            // sell amount subtracted from stock and updated to screen
            factoryObject.stock = factoryObject.stock - sellAmount;
            moneyObject.money = moneyObject.money + sellPrice * sellAmount;
            moneyObject.balance.SetText(moneyObject.money + "€");

            string stockNew = Convert.ToString(factoryObject.stock);
            stockText.SetText(stockNew);
        } else
        {
            sellError.SetActive(true);
        }
        

        // if stock below 1 disable sell button
        if (factoryObject.stock < 1)
        {
            sellButton.enabled = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
