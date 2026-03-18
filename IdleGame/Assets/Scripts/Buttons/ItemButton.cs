using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{

    #region VARIABLES

    private ShopManager shopManager;

    public TextMeshProUGUI itemTitle;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemAmount;
    public TextMeshProUGUI itemCost;

    #endregion

    #region MONOBEHVAIOUR FUNCTIONS

    private void Start()
    {
        shopManager = ShopManager.Instance;
    }

    #endregion

    #region ADDITEM

    public void BuyItem(int _itemId)
    {
        shopManager.PurchaseItem(_itemId);
        IncItemAmountUI(_itemId);
        ChangeItemCost(_itemId);
    }

    public void IncItemAmountUI(int _itemId)
    {
        itemAmount.text = (shopManager.itemList[_itemId].amount).ToString("F0");
    }

    public void ChangeItemCost(int _itemId)
    {
        itemCost.text = "Cost: " + (shopManager.itemList[_itemId].cost).ToString("F0");
    }

    #endregion

}