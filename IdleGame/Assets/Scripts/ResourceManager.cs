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
    [SerializeField] private double views;
    [SerializeField] private uint exponent;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI viewsUI;

    public static ResourceManager Instance;
    private DataManager dataManager;

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
        dataManager = DataManager.Instance;
        DataManager.Instance.saveableObjects.Add(this)  ;
    }

    //--------//
    void Start()
    //--------//
    {

    }

    private void Update()
    {

    }

    #endregion

    #region RESOURCE FUNCTIONS

    //-------------------//
    private void ViewCycle()
    //-------------------//
    {




    }

    //-----------------------------//
    public void AddViews(uint _views)
    //-----------------------------//
    {
        if (!(_views / views < .1) || views == 0)
        {
            views = BigDouble.Add(views, _views).ToDouble();
            UpdateViewUI();
        }
    }

    #endregion

    #region UI FUNCTIONS

    //--------------------------------------//
    public void UpdateViewUI()
    //--------------------------------------//
    {
        viewString = ConvertToString(views);
        viewsUI.text = "Views: " + viewString;
    }

    #endregion

    #region EXPONENT FUNCTIONS

    private string ConvertToString(BigDouble _int, double _exponent)
    {
        string num;
        num = BigDouble.Pow(_int, exponent).ToString("F0");
        return num;
    }

    #endregion

    #region DATA MANAGEMENT

    public void LoadVariables()
    {
        views = dataManager.data.views;
        viewModifier = dataManager.data.viewModifier;

        InitializeData();
    }

    public void SaveVariables()
    {
        dataManager.data.views = views;
        dataManager.data.viewModifier = viewModifier;
    }

    private void InitializeData()
    {
        UpdateViewUI();
    }

    #endregion

}
