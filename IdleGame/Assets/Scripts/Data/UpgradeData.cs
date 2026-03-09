using UnityEngine;
using BreakInfinity;

public enum UpgradeType
{
    Modifier,
    AddButton
}

[System.Serializable]
public class UpgradeData
{
    public string upgradeTitle;
    public string upgradeDescription;
    public UpgradeType type;
    public BigDouble cost;
    public BigDouble addAmount;
    public bool purchased;
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
