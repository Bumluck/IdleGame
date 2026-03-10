using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public interface ISaveable
{
    public void LoadVariables();
    public void SaveVariables();
}


public class DataManager : MonoBehaviour
{
    #region VARIABLES

    private const string GameDataKey = "GameData";
    public static DataManager Instance;

    [Header("Current Data from PlayerPrefs - DOES NOT REFLECT REALTIME DATA")]
    public GameData data;

    public List<ISaveable> saveableObjects;

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
            data = LoadData();
            saveableObjects = new List<ISaveable>();
            Debug.Log("Saveable List created");
        }
    }

    private void Start()
    {
        StartCoroutine(PassDataToObjects());
    }

    void OnApplicationQuit()
    {
        GetDataFromObjects();
        SaveData(data);
    }

    #endregion

    #region CALL ISAVEABLE FUNCTIONS

    private IEnumerator PassDataToObjects()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log(saveableObjects.Count);
        Debug.LogWarning("Beginning to pass data to objects...");
        foreach (ISaveable s in saveableObjects)
        {
            s.LoadVariables();
        }
        yield return null;
    }

    private void GetDataFromObjects()
    {
        Debug.LogWarning("Beginning to get data from objects...");
        foreach (ISaveable s in saveableObjects)
        {
            s.SaveVariables();
        }
    }

    #endregion

    #region DATA DISK MANAGEMENT

    public void SaveData(GameData data)
    {
        if (data == null)
        {
            Debug.LogError("The data you are trying to save is null");
            return;
        }
        Debug.Log("data is not null, attempting to save");
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(GameDataKey, json);
        PlayerPrefs.Save();
    }

    public GameData LoadData()
    {
        GameData data;
        if (!PlayerPrefs.HasKey(GameDataKey))
        {
            Debug.LogWarning("No saved game data found creating new save game data...");
            data = new GameData();
            return data;
        }

        string json = PlayerPrefs.GetString(GameDataKey);
        data = JsonUtility.FromJson<GameData>(json);
        Debug.Log(PlayerPrefs.HasKey(GameDataKey));
        return data;


        //data = new GameData();
        //return data;
    }

    #endregion
}
