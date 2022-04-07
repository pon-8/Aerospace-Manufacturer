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
    public Button buildButton;
    //public Button sellButton;
    public TextMeshProUGUI stockText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Button bbtn = buildButton.GetComponent<Button>();
        //Button sbtn = sellButton.GetComponent<Button>();
        bbtn.onClick.AddListener(BuildOnClick);
        //sbtn.onClick.AddListener(SellOnClick);
    }

    //void SellOnClick()
    //{
    //    stock--;
    //    string stockNew = Convert.ToString(stock);
    //    stockText.SetText(stockNew);
    //}

    void BuildOnClick()
    {
        stock++;
        string stockNew = Convert.ToString(stock);
        stockText.SetText(stockNew);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
