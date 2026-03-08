using UnityEngine;
using System;
using BreakInfinity;

[System.Serializable]
public class GameData
{
    public uint exponent;
    public BigDouble views;
    public float viewModifier;

    public GameData()
    {
        exponent = 0;
        views = 0;
        viewModifier = 1;
    }

}
