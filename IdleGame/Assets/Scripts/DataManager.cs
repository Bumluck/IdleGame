using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BreakInfinity;

public interface ISaveable
{
    public void LoadVariables();
    public void SaveVariables();
}

[Serializable]
public struct PostButtonData
{
    public string buttonAdd;
    public string buttonMod;

    public PostButtonData(string _buttonAdd, string _buttonMod)
    {
        buttonAdd = _buttonAdd;
        buttonMod = _buttonMod;
    }
}

public class DataManager : MonoBehaviour
{
    #region VARIABLES

    private const string GameDataKey = "GameData";
    public static DataManager Instance;

    [Header("Current Data from PlayerPrefs - DOES NOT REFLECT REALTIME DATA")]
    public GameData data;

    public List<ISaveable> saveableObjects;
    //Separate postButton for XML data saving, all saveable objects will use Json
    public PostButton postButton;

    private string _directoryPath;

    private string _playSessionDataPath;
    private string _xmlPostButtonPath;
    private string _jsonGameData;

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
            _directoryPath = Application.persistentDataPath + "/Player_Data/";
            _xmlPostButtonPath = _directoryPath + "PostButtonData.xml";
            _jsonGameData = _directoryPath + "GameData.json";
            _playSessionDataPath = _directoryPath + "PlaySessions.txt";

            Instance = this;
            data = LoadData();
            saveableObjects = new List<ISaveable>();
            Debug.Log("Saveable List created");

            if (Directory.Exists(_directoryPath))
            {
                Debug.Log(_directoryPath);
                Debug.Log("Directory already exists...");
                return;
            }
            else
            {
                Directory.CreateDirectory(_directoryPath);
                Debug.Log("New Directory created!");
            }
        }
    }
    
    private void Start()
    {
        StartCoroutine(PassDataToObjects());

        if (File.Exists(_playSessionDataPath))
        {
            File.AppendAllText(_playSessionDataPath, $"Session started: {DateTime.Now}\n");
            Debug.Log("File exists... Attempting to write session start time...");
        }
        else
        {
            File.WriteAllText(_playSessionDataPath, $"Session started: {DateTime.Now}\n");
            Debug.Log("File supposedly does not exist... Attmepting to create new play session file...");
        }

    }

    void OnApplicationQuit()
    {
        GetDataFromObjects();
        SaveData(data);

        SavePostButtonData(postButton.buttonAdd.ToString("F0"), postButton.buttonMod.ToString("F0"));

        if (File.Exists(_playSessionDataPath))
        {
            File.AppendAllText(_playSessionDataPath, $"Session ended: {DateTime.Now}\n");
        }
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

        PostButtonData dataFromDisk = LoadPostButtonData();
        postButton.buttonAdd = BigDouble.Parse(dataFromDisk.buttonAdd);
        postButton.buttonMod = float.Parse(dataFromDisk.buttonMod);

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
        string json = JsonUtility.ToJson(data, true);

        using (StreamWriter stream = File.CreateText(_jsonGameData))
        {
            stream.Write(json);
        }

    }

    public GameData LoadData()
    {
        GameData data;
        Debug.Log(_jsonGameData);
        if (!File.Exists(_jsonGameData))
        {
            Debug.LogWarning("No saved game data found creating new save game data...");
            data = new GameData();
            return data;
        } 
        else
        {
            using (StreamReader stream = new StreamReader(_jsonGameData))
            {
                var jsonstring = stream.ReadToEnd();
                data = JsonUtility.FromJson<GameData>(jsonstring);
                return data;
            }
        }
    }

    public PostButtonData LoadPostButtonData()
    {
        if (File.Exists(_xmlPostButtonPath))
        {
            var xmlSerializer = new XmlSerializer(typeof(PostButtonData));
            using (FileStream stream = File.OpenRead(_xmlPostButtonPath))
            {
                var buttonData = (PostButtonData)xmlSerializer.Deserialize(stream);
                return buttonData;
            }
        }
        else
        {
            Debug.Log("Creating new PostButtonData struct with default values");
            return new PostButtonData("1", "1");
        }
    }

    public void SavePostButtonData(string _buttonAdd, string _buttonMod)
    {
        var xmlSerializer = new XmlSerializer(typeof(PostButtonData));

        PostButtonData _currentPostButtonData = new PostButtonData(_buttonAdd,_buttonMod);

        using (FileStream stream = File.Create(_xmlPostButtonPath))
        {
            xmlSerializer.Serialize(stream, _currentPostButtonData);
        }
    }

    #endregion
}
