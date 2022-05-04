using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Code Description:
/// Currently just sets the initial balance of the game.
/// Other scripts call balance object and money variable when changing balance.
/// In future will utilize database to fetch saved information.
/// </summary>


public class Money : MonoBehaviour
{
    public static Money instance;
    public TextMeshProUGUI balance;     //text field in game
    public int money = 50;      //initial balance
    
    // Start is called before the first frame update
    void Start()
    {
        //creating instance
        if (instance == null)
        {
            instance = this;
        }

        //setting initial balance
        balance.SetText(money + "€");
    }
}
