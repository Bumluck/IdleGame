using UnityEngine;

public class ItemButton : MonoBehaviour
{

    #region VARIABLES

    private ShopManager shopManager;


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
    }

    #endregion

}
