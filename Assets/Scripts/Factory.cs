using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Code Description:
/// 
/// Build cost will later be deduced on materials used and build amounts. (I'm lightyears away from implementing that...)
/// </summary>


public class Factory : MonoBehaviour
{
    public static Factory instance;
    public int stock;       // Amount of aircraft stored
    public int buildCost;
    public Button buildButton;
    public Button factoryButton;        // Open factory view when pressed
    public TextMeshProUGUI stockText;
    private Money moneyObject;      // Local reference to Money script
    public GameObject buildError;   // No money error

    // Start is called before the first frame update
    void Start()
    {
        //creating instance
        if (instance == null)
        {
            instance = this;
        }

        // Fetching Money script for local referencing
        moneyObject = GetComponent<Money>();

        // Buttons on the factory view
        Button bbtn = buildButton.GetComponent<Button>();
        Button fbtn = factoryButton.GetComponent<Button>();

        // Listeners for detecting button presses
        bbtn.onClick.AddListener(BuildOnClick);
        fbtn.onClick.AddListener(UpdateOnClick);

        // Setting initial build cost
        buildCost = 5;
    }

    // Tasks run when factory view is entered.
    void UpdateOnClick()
    {
        // Update stock amount
        string stockNew = Convert.ToString(stock);
        stockText.SetText(stockNew);

        // Disable build error
        buildError.SetActive(false);
    }

    // Tasks run when Build Button is pressed.
    public void BuildOnClick()
    {
        // Is there enough money to build?
        if (moneyObject.money >= buildCost)
        {
            // Enough money

            // Add new build to stock
            stock++; //change when implementing buildAmount

            // Update stock
            string stockNew = Convert.ToString(stock);
            stockText.SetText(stockNew);

            // Take build cost from money
            moneyObject.money = moneyObject.money - buildCost;
            moneyObject.balance.SetText(moneyObject.money + "€");

            // disable build error
            buildError.SetActive(false);
        } else
        {
            // No money

            // Activate buildError
            buildError.SetActive(true);
        }
    }
}
