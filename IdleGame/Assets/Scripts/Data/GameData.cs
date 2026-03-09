using UnityEngine;
using System;
using BreakInfinity;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class GameData
{
    public float viewModifier;
    public string views;
    public string viewRate;
    public string money;
    public string adrev;
    public string buttonAdd;
    public GameData()
    {
        viewModifier = 1;
        views = "0";
        viewRate = "0";
        money = "0";
        adrev = "0";
        buttonAdd = "1";
    }

}
