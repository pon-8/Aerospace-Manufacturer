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
    public TMP_InputField buildInput;
    private Money moneyObject;      // Local reference to Money script
    public TextMeshProUGUI buildErrorTxt;   // error txt component

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

        TMP_InputField setBuildA = buildInput.GetComponent<TMP_InputField>();

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
        buildError(0);
    }

    // Tasks run when Build Button is pressed.
    public void BuildOnClick()
    {
        if (buildInput.GetComponentInChildren<TMP_InputField>().text.Length > 0)
        {
            int buildAmount = Convert.ToInt32(buildInput.GetComponentInChildren<TMP_InputField>().text);

            if (buildAmount > 0)
            {
                int totalCost = buildCost * buildAmount;

                if (moneyObject.money >= totalCost)
                {
                    stock = stock + buildAmount;

                    string stockNew = Convert.ToString(stock);
                    stockText.SetText(stockNew);

                    moneyObject.money = moneyObject.money - totalCost;
                    moneyObject.balance.SetText(moneyObject.money + "€");

                    buildError(0);
                } else
                {
                    buildError(1);
                }
            } else
            {
                buildError(2);
            }
        } else
        {
            buildError(3);
        }
    }

    void buildError(int error)
    {
        switch (error)
        {
            case 1:
                buildErrorTxt.SetText("Not enough money!");
                buildErrorTxt.gameObject.SetActive(true);
                break;
            case 2:
                buildErrorTxt.SetText("Please type a positive number!");
                buildErrorTxt.gameObject.SetActive(true);
                break;
            case 3:
                buildErrorTxt.SetText("Please input build amount!");
                buildErrorTxt.gameObject.SetActive(true);
                break;
            default:
                buildErrorTxt.SetText("");
                buildErrorTxt.gameObject.SetActive(false);
                break;
        }
    }
}


