using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour, ISaveable
{

    #region VARIABLES

    public List<UpgradeData> upgradeList;
    private DataManager dataManager;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    private void Start()
    {
        dataManager = DataManager.Instance;
        dataManager.saveableObjects.Add(this);
    }

    #endregion

    #region ISAVEABLE FUNCTIONS

    public void LoadVariables()
    {

    }

    public void SaveVariables()
    {

    }

    #endregion

    //Massive list of functions that have to change viewmodifier or post button effect

    //Separate viewmodifier, adrevmodifier, and post button effect into different lists of methods
    //private methods that return a float to add together to get the new total modifiers



}
