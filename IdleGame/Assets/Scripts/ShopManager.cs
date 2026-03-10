using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, ISaveable
{

    #region VARIABLES

    public List<ItemData> itemList;
    public List<Button> buttonList;
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
        dataManager.saveableObjects.Add(this);
    }

    #endregion

    #region SHOP FUNCTIONS

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
            itemList[_itemId].cost *= itemList[_itemId].costMultiplier;
            itemList[_itemId].cost = itemList[_itemId].cost.Floor();
            itemList[_itemId].amount++;
            //itemAmountTextList[_itemId].text = itemList[_itemId].amount.ToString("F0");
            resourceManager.UpdateViewUI();
            UpdateViewRate();
        }
    }

    #endregion

    #region ITEM UI FUNCTIONS

    private void SetItemUI()
    {
        foreach(ItemData i in itemList)
        {
            ItemButton currentButton = buttonList[itemList.IndexOf(i)].GetComponent<ItemButton>();
            currentButton.itemTitle.text = i.itemTitle;
            currentButton.itemDescription.text = i.itemDescription;
            currentButton.itemAmount.text = i.amount.ToString("F0");
        }
    }

    #endregion

    #region ISAVEABLE FUNCTIONS

    public void LoadVariables()
    {
        itemList[0].amount = BigDouble.Parse(dataManager.data.catAmount);
        itemList[0].cost = BigDouble.Parse(dataManager.data.catCost);
        itemList[1].amount = BigDouble.Parse(dataManager.data.foodAmount);
        itemList[1].cost = BigDouble.Parse(dataManager.data.foodCost);
        itemList[2].amount = BigDouble.Parse(dataManager.data.memeAmount);
        itemList[2].cost = BigDouble.Parse(dataManager.data.memeCost);
        itemList[3].amount = BigDouble.Parse(dataManager.data.videogameAmount);
        itemList[3].cost = BigDouble.Parse(dataManager.data.videogameCost);

        InitializeData();
    }

    public void SaveVariables()
    {
        dataManager.data.catAmount = itemList[0].amount.ToString("F0");
        dataManager.data.catCost = itemList[0].cost.ToString("F0");
        dataManager.data.foodAmount = itemList[1].amount.ToString("F0");
        dataManager.data.foodCost = itemList[1].cost.ToString("F0");
        dataManager.data.memeAmount = itemList[2].amount.ToString("F0");
        dataManager.data.memeCost = itemList[2].cost.ToString("F0");
        dataManager.data.videogameAmount = itemList[3].amount.ToString("F0");
        dataManager.data.videogameCost = itemList[3].cost.ToString("F0");
    }

    public void InitializeData()
    {
        SetItemUI();
    }

    #endregion

}
