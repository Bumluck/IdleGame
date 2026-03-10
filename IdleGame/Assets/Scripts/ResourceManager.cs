using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using BreakInfinity;

public class ResourceManager : MonoBehaviour, ISaveable
{

    #region VARIABLES

    [Header("Views Stuff")]
    [SerializeField] private float viewModifier;
    [SerializeField] private string viewString;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI viewsUI;

    [SerializeField] public Dictionary<string, BigDouble> resourceList;
    public static ResourceManager Instance;
    private DataManager dataManager;
    private ShopManager shopManager;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    //----------------//
    private void Awake()
    //----------------//
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {

    }

    //--------//
    void Start()
    //--------//
    {
        dataManager = DataManager.Instance;
        shopManager = ShopManager.Instance;
        DataManager.Instance.saveableObjects.Add(Instance);
        resourceList = new Dictionary<string, BigDouble>();
    }

    private void Update()
    {
        ViewCycle();
    }

    #endregion

    #region RESOURCE FUNCTIONS

    //-------------------//
    private void ViewCycle()
    //-------------------//
    {
        resourceList["views"] += resourceList["viewRate"];
        UpdateViewUI();
    }
    
    //-----------------------------//
    public void AddViews(BigDouble _views)
    //-----------------------------//
    {
        resourceList["views"] = BigDouble.Add(resourceList["views"], _views);
        UpdateViewUI();
    }

    #endregion

    #region UI FUNCTIONS

    //--------------------------------------//
    public void UpdateViewUI()
    //--------------------------------------//
    {
        viewString = BigDoubleToString(resourceList["views"]);
        viewsUI.text = "Views: " + viewString;
    }

    #endregion

    #region EXPONENT FUNCTIONS

    private string BigDoubleToString(BigDouble _int)
    {
        string num;
        num = _int.ToString("F0");
        return num;
    }

    #endregion

    #region DATA MANAGEMENT

    public void LoadVariables()
    {
        resourceList["views"] = BigDouble.Parse(dataManager.data.views);
        resourceList["viewRate"] = BigDouble.Parse(dataManager.data.viewRate);
        resourceList["money"] = BigDouble.Parse(dataManager.data.money);
        resourceList["adrev"] = BigDouble.Parse(dataManager.data.adrev);
        viewModifier = dataManager.data.viewModifier;

        InitializeData();
        
    }

    public void SaveVariables()
    {
        dataManager.data.views = resourceList["views"].ToString("F0");
        dataManager.data.viewRate = resourceList["viewRate"].ToString("F0");
        dataManager.data.money = resourceList["money"].ToString("F0");
        dataManager.data.adrev = resourceList["adrev"].ToString("F0");
        dataManager.data.viewModifier = viewModifier;
    }

    private void InitializeData()
    {
        UpdateViewUI();
    }

    #endregion

}
