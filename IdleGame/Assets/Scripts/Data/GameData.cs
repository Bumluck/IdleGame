using UnityEngine;
using System;
using BreakInfinity;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class GameData
{
    //ResourceManager
    public float viewModifier;
    public string views;
    public string viewRate;
    public string money;
    public string adrev;

    //PostButton
    public string buttonAdd;

    //ShopManager
    public string catAmount;
    public string catCost;

    public GameData()
    {
        

        //ResourceManager
        viewModifier = 1;
        views = "0";
        viewRate = "0";
        money = "0";
        adrev = "0";

        //PostButton
        buttonAdd = "1";

        //ShopManager
        catAmount = "0";
        catCost = "25";

    }

}
