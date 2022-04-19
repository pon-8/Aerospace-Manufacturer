using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Market : MonoBehaviour
{
    public static Market instance;
    public Button sellButton;
    public Button marketButton;
    public TextMeshProUGUI stockText;
    private Factory factoryObject;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        factoryObject = GetComponent<Factory>();

        Button sbtn = sellButton.GetComponent<Button>();
        Button mbtn = marketButton.GetComponent<Button>();

        sbtn.onClick.AddListener(SellOnClick);
        mbtn.onClick.AddListener(UpdateOnClick);

        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);
    }

    void UpdateOnClick()
    {
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);
    }

    void SellOnClick()
    {
        factoryObject.stock = factoryObject.stock -1;
        string stockNew = Convert.ToString(factoryObject.stock);
        stockText.SetText(stockNew);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
