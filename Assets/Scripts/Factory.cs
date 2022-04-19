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
    public Button factoryButton;
    public TextMeshProUGUI stockText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Button bbtn = buildButton.GetComponent<Button>();
        Button fbtn = factoryButton.GetComponent<Button>();

        bbtn.onClick.AddListener(BuildOnClick);
        fbtn.onClick.AddListener(UpdateOnClick);

        
    }

    void UpdateOnClick()
    {
        string stockNew = Convert.ToString(stock);
        stockText.SetText(stockNew);
    }

    public void BuildOnClick()
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
