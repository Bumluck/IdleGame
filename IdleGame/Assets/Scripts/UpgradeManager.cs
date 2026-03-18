using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour, ISaveable
{

    #region VARIABLES

    public List<UpgradeData> upgradeList;
    public List<GameObject> buttonList;
    private DataManager dataManager;
    private ResourceManager resourceManager;
    private PostButton postButton;

    [SerializeField] private GameObject upgradeLayoutGroup;
    [SerializeField] private GameObject upgradeButtonPrefab;

    public static UpgradeManager Instance;

    private bool doneLoading;

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
            doneLoading = false;
        }
    }

    private void Start()
    {
        postButton = PostButton.Instance;
        resourceManager = ResourceManager.Instance;
        dataManager = DataManager.Instance;
        dataManager.saveableObjects.Add(this);
    }

    private void Update()
    {
        if (doneLoading == true)
        {
            UnlockUpgrades();
        }
    }

    #endregion

    #region UNLOCK UPGRADES

    public void UnlockUpgrades()
    {
        bool buttonSpawned = false;
        for (int i = 0; i < upgradeList.Count; i++)
        {
            if (upgradeList[i].state == UpgradeState.Locked && resourceManager.resourceList["views"] >= (.25f * upgradeList[i].cost))
            {
                upgradeList[i].state = UpgradeState.Available;

                if (!buttonSpawned)
                {
                    buttonSpawned = true;
                    CreateButton(i);
                    Debug.Log("Button created through UnlockUpgrades()");
                }
            }
        }
    }

    public void InitUnlockedUpgrades()
    {
        for (int i = 0; i < upgradeList.Count; i++)
        {
            if (upgradeList[i].state == UpgradeState.Available)
            {
                CreateButton(i);
                Debug.Log("Button created through InitUnlockedUpgrades()");
            }
        }

    }

    public void CreateButton(int i)
    {
        GameObject currentButton = Instantiate(upgradeButtonPrefab, upgradeLayoutGroup.transform);
        UpgradeButton buttonData = currentButton.GetComponent<UpgradeButton>();

        buttonData.upgradeTitle.text = upgradeList[i].upgradeTitle;
        buttonData.upgradeDesc.text = upgradeList[i].upgradeDescription;
        buttonData.upgradeCost.text = "Cost: " + upgradeList[i].cost.ToString("F0");
        buttonData.upgradeId = i;

        buttonList.Add(currentButton);
    }

    #endregion

    #region PURCHASE UPGRADES

    public void PurchaseUpgrade(int _upgradeId)
    {
        if (resourceManager.resourceList["views"] >= upgradeList[_upgradeId].cost)
        {
            resourceManager.resourceList["views"] -= upgradeList[_upgradeId].cost;

            upgradeList[_upgradeId].state = UpgradeState.Purchased;

            switch (upgradeList[_upgradeId].type)
            {
                case ResourceType.PostButton:
                    postButton.AddButtonMod(upgradeList[_upgradeId].effect);
                    break;
                case ResourceType.Views:
                    resourceManager.AddViewModifier(upgradeList[_upgradeId].effect);
                    break;
                case ResourceType.AdRev:
                    //Nothing right now since adrev system is not in yet
                    break;
                default:
                    break;
            }

            Destroy(buttonList[_upgradeId].gameObject);
        }
    }

    #endregion

    #region ISAVEABLE FUNCTIONS

    public void LoadVariables()
    {
        upgradeList[0].state = (UpgradeState)dataManager.data.teenState;
        upgradeList[1].state = (UpgradeState)dataManager.data.shortVidState;
        upgradeList[2].state = (UpgradeState)dataManager.data.smallAdState;

        InitUnlockedUpgrades();
        doneLoading = true;
        //Debug.Log("Upgrades done loading");
    }

    public void SaveVariables()
    {
        dataManager.data.teenState = (int)upgradeList[0].state;
        dataManager.data.shortVidState = (int)upgradeList[1].state;
        dataManager.data.smallAdState = (int)upgradeList[2].state;
    }

    #endregion

}
