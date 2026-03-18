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

    public float timer;

    public static ResourceManager Instance;
    private DataManager dataManager;
    private ShopManager shopManager;

    private bool doneLoading;

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
            doneLoading = false;
        }
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
        //Run ViewCycle() every second
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (doneLoading)
            {
                ViewCycle();
                timer = 0f;
            }
        }
    }

    #endregion

    #region RESOURCE FUNCTIONS

    //-------------------//
    private void ViewCycle()
    //-------------------//
    {
        resourceList["views"] += resourceList["viewRate"] * viewModifier;
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

    #region MODIFIER FUNCTIONS

    public void AddViewModifier(float _add)
    {
        viewModifier += _add;
    }

    #endregion

    #region UI FUNCTIONS

    //--------------------------------------//
    public void UpdateViewUI()
    //--------------------------------------//
    {
        viewString = resourceList["views"].ToString("F0");
        viewsUI.text = "Views: " + viewString;
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

        doneLoading = true;
    }

    #endregion

}
