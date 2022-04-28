using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Factory : MonoBehaviour
{
    public static Factory instance;
    public int stock;
    public int buildCost;
    public Button buildButton;
    public Button factoryButton;
    public TextMeshProUGUI stockText;
    private Money moneyObject;
    public GameObject buildError;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        moneyObject = GetComponent<Money>();

        Button bbtn = buildButton.GetComponent<Button>();
        Button fbtn = factoryButton.GetComponent<Button>();

        bbtn.onClick.AddListener(BuildOnClick);
        fbtn.onClick.AddListener(UpdateOnClick);

        buildCost = 5;
    }

    void UpdateOnClick()
    {
        string stockNew = Convert.ToString(stock);
        stockText.SetText(stockNew);
    }

    public void BuildOnClick()
    {
        if (moneyObject.money >= buildCost)
        {
            stock++;
            string stockNew = Convert.ToString(stock);
            stockText.SetText(stockNew);

            moneyObject.money = moneyObject.money - buildCost;
            moneyObject.balance.SetText(moneyObject.money + "€");

            buildError.SetActive(false);
        } else
        {
            buildError.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
