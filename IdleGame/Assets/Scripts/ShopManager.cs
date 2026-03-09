using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;

public class ShopManager : MonoBehaviour
{

    #region VARIABLES

    public List<ItemData> itemList;
    private DataManager dataManager;
    private ResourceManager resourceManager;

    public static ShopManager Instance;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        dataManager = DataManager.Instance;
        resourceManager = ResourceManager.Instance;
    }

    #endregion

    public void UpdateViewRate()
    {
        BigDouble newviewRate = 0;
        foreach (ItemData i in itemList)
        {
            newviewRate += (i.amount * i.viewRateAdd);
        }
        resourceManager.resourceList["viewRate"] = newviewRate;
    }


    public void PurchaseItem(int _itemId)
    {
        if (resourceManager.resourceList["views"] >= itemList[_itemId].cost)
        {
            resourceManager.resourceList["views"] -= itemList[_itemId].cost;
            itemList[_itemId].cost = itemList[_itemId].costMultiplier;
            itemList[_itemId].amount++;
            UpdateViewRate();
        }
    }

}
