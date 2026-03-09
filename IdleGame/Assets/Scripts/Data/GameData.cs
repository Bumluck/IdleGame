using UnityEngine;
using System;
using BreakInfinity;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class GameData
{
    public float viewModifier;
    public Dictionary<string, BigDouble> resourceList;
    public GameData()
    {
        viewModifier = 1;
        resourceList = new Dictionary<string, BigDouble>();
        resourceList["views"] = 0;
        resourceList["viewRate"] = 0;
        resourceList["money"] = 0;
        resourceList["adrev"] = 0;
    }

}
