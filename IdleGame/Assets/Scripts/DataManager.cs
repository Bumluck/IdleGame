using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region VARIABLES

    private const string GameDataKey = "GameData";

    public static DataManager Instance;

    #endregion

    #region MONOBEHAVIOUR FUNCTIONS

    private void Start()
    {
        if (Instance == null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    #region DATA MANAGEMENT

    public void SaveData(GameData data)
    {
        if (data != null)
        {
            Debug.LogError("The data you are trying to save is null");
            return;
        }
        
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(GameDataKey, json);
        PlayerPrefs.Save();
    }

    public GameData LoadData()
    {
        if (!PlayerPrefs.HasKey(GameDataKey))
        {
            Debug.LogWarning("No saved game data found...");
        }

        string json = PlayerPrefs.GetString(GameDataKey);
        GameData data = JsonUtility.FromJson<GameData>(json);

        return data;
    }

    #endregion
}
