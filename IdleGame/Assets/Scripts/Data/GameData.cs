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

    //ShopManager
    public string catAmount;
    public string catCost;
    public string foodAmount;
    public string foodCost;
    public int foodUnlocked;
    public string memeAmount;
    public string memeCost;
    public int memeUnlocked;
    public string videogameAmount;
    public string videogameCost;
    public int videogameUnlocked;
    public string politicsAmount;
    public string politicsCost;
    public int politicsUnlocked;

    //UpgradeManager
    public int teenState;
    public int shortVidState;
    public int smallAdState;
    public int cryptoBrosState;

    //Post Button
    public string buttonAdd;
    public string buttonMod;

    public GameData()
    {
        
        //ResourceManager
        viewModifier = 1;
        views = "0";
        viewRate = "0";
        money = "0";
        adrev = "0";

        //ShopManager
        catAmount = "0";
        catCost = "25";
        foodAmount = "0";
        foodCost = "1000";
        foodUnlocked = 0;
        memeAmount = "0";
        memeCost = "15000";
        memeUnlocked = 0;
        videogameAmount = "0";
        videogameCost = "50000";
        videogameUnlocked = 0;
        politicsAmount = "0";
        politicsCost = "100000";
        politicsUnlocked = 0;

        //UpgradeManager
        teenState = 0;
        shortVidState = 0;
        smallAdState = 0;
        cryptoBrosState = 0;

        //Post Button
        buttonAdd = "1";
        buttonMod = "1";
    }

}
