using UnityEngine;
using BreakInfinity;

public enum UpgradeState
{
    Locked,
    Available,
    Purchased
}

public enum ResourceType
{
    Views,
    PostButton,
    AdRev
}

[System.Serializable]
public class UpgradeData
{
    public string upgradeTitle;
    public string upgradeDescription;
    public UpgradeState state;
    public ResourceType type;
    public BigDouble cost;
    public BigDouble effect;
}

[System.Serializable]
public class ItemData
{
    public string itemTitle;
    public string itemDescription;
    public BigDouble cost;
    public BigDouble amount;
    public float costMultiplier;
    public BigDouble viewRateAdd;
    public int itemId;
}
