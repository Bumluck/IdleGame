using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Numerics;

public class ResourceManager : MonoBehaviour
{

    #region VARIABLES

    [Header("Views Stuff")]
    [SerializeField] private uint viewModifier;
    [SerializeField] private string viewString;
    [SerializeField] private BigInteger views;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI viewsUI;

    public static ResourceManager Instance;

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

    //--------//
    void Start()
    //--------//
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

    private void Update()
    {

    }

    #endregion

    #region RESOURCE FUNCTIONS

    //-------------------//
    private void ViewCycle()
    //-------------------//
    {
        uint addAmount;




    }

    //-----------------------------//
    public void AddViews(uint _views)
    //-----------------------------//
    {
        views += _views;
        UpdateViewUI();
    }

    #endregion

    #region UI FUNCTIONS

    //--------------------------------------//
    public void UpdateViewUI()
    //--------------------------------------//
    {
        viewString = views.ToString();
        viewsUI.text = "Views: " + viewString;
    }

    #endregion

    #region DATA MANAGEMENT

    //Add method to create a new list entry when the player gets a total views above the sizeof(ulong)

    //Saving and Loading code to PlayerPrefs, full save and load seems overkill for now

    #endregion

}
