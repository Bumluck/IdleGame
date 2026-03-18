using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{

    #region VARIABLES

    private UpgradeManager upgradeManager;

    public int upgradeId;

    public TextMeshProUGUI upgradeTitle;
    public TextMeshProUGUI upgradeDesc;
    public TextMeshProUGUI upgradeCost;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradeManager = UpgradeManager.Instance;
    }

    #endregion

    #region BUY UPGRADES

    public void BuyUpgrade()
    {
        upgradeManager.PurchaseUpgrade(upgradeId);
    }

    #endregion

}
