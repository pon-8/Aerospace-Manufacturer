using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Market : MonoBehaviour
{
    //needed variables for market
    public TextMeshProUGUI sellErrorTxt;     // text field for errors
    public static Market instance;
    public Button sellButton;
    public Button marketButton;
    public TextMeshProUGUI stockText;
    private Factory factoryObject;  // Local reference to factory script
    private Money moneyObject;      // Local reference to money script
    private int sellAmount;     // Default sell amount
    private int sellPrice;
    public TMP_InputField setAmount;
    public TMP_InputField setPrice;

    // Start is called before the first frame update
    void Start()
    {
        // creating instance
        if (instance == null)
        {
            instance = this;
        }

        // creating local references to Factory and Money
        factoryObject = GetComponent<Factory>();
        moneyObject = GetComponent<Money>();

        // fetching button components
        Button sbtn = sellButton.GetComponent<Button>();
        Button mbtn = marketButton.GetComponent<Button>();

        // fetching input field
        TMP_InputField setA = setAmount.GetComponent<TMP_InputField>();
        TMP_InputField setP = setPrice.GetComponent<TMP_InputField>();

        // creating button listeners
        sbtn.onClick.AddListener(SellOnClick);
        mbtn.onClick.AddListener(UpdateOnClick);

        // updating stock to Stock Amount text object
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);

        // Resetting all errors
        sellError(0);
    }

    // objects to update when market UI is entered
    void UpdateOnClick()
    {
        // stock update
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);

        // resetting error messages
        sellError(0);
    }

    // actions when sellButton is pressed
    void SellOnClick()
    {

        // Does Amount field have input?
        if (setAmount.GetComponentInChildren<TMP_InputField>().text.Length > 0)
        {
            // It has

            // Take text from imput field and convert to Integer
            string sellAContent = setAmount.GetComponentInChildren<TMP_InputField>().text;
            sellAmount = Convert.ToInt32(sellAContent);

            //resetting negative number error
            sellError(0);

            if (setPrice.GetComponentInChildren<TMP_InputField>().text.Length > 0)
            {
                // It has

                string sellPContent = setPrice.GetComponentInChildren<TMP_InputField>().text;
                sellPrice = Convert.ToInt32(sellPContent);

                // is either input negative?
                if (sellAmount < 0 || sellPrice < 0)
                {
                    // yup

                    // Display error message
                    sellError(2);
                }
                else if (sellAmount <= factoryObject.stock) // is there enough stock?
                {
                    // yes

                    // reset errors
                    sellError(0);

                    // sell amount subtracted from stock and update balance to match.
                    factoryObject.stock = factoryObject.stock - sellAmount;
                    moneyObject.money = moneyObject.money + sellPrice * sellAmount;
                    moneyObject.balance.SetText(moneyObject.money + "€");

                    string stockNew = Convert.ToString(factoryObject.stock);
                    stockText.SetText(stockNew);
                }
                else
                {
                    // No and no, display not enough stock error.
                    sellError(1);
                }
            } 
            else
            {
                sellError(4);
            }

        } else
        {
            // It doesn't

            // Display amount error
            sellError(3);
        }

        
        

        
    }

    void sellError(int error)
    {
        switch (error)
        {
            case 1:
                sellErrorTxt.SetText("Not enough stock!");
                sellErrorTxt.gameObject.SetActive(true);
                break;
            case 2:
                sellErrorTxt.SetText("Please type a positive number!");
                sellErrorTxt.gameObject.SetActive(true);
                break;
            case 3:
                sellErrorTxt.SetText("Please input sell amount!");
                sellErrorTxt.gameObject.SetActive(true);
                break;
            case 4:
                sellErrorTxt.SetText("Please input sell price!");
                sellErrorTxt.gameObject.SetActive(true);
                break;
            default:
                sellErrorTxt.SetText("");
                sellErrorTxt.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
