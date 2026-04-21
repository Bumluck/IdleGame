using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using System;
public class PostButton : MonoBehaviour
{
    #region VARIABLES

    public BigDouble buttonAdd;
    public float buttonMod;
    private DataManager dataManager;

    public static PostButton Instance;

    public event Action postButtonPressed;

    #endregion

    public void OnPostButtonPress()
    {
        ResourceManager.Instance.AddViews(buttonAdd * buttonMod);
        postButtonPressed?.Invoke();
    }

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
        }
    }

    private void Start()
    {
        dataManager = DataManager.Instance;
        dataManager.postButton = this;
    }

    #endregion

    #region ADD STATS

    public void AddButtonMod(float _add)
    {
        buttonMod += _add;
    }

    #endregion

    #region ISAVEABLE FUNCTIONS
    /*
    public void LoadVariables()
    {

        buttonAdd = BigDouble.Parse(dataManager.data.buttonAdd);
        buttonMod = float.Parse(dataManager.data.buttonMod);

    }

    public void SaveVariables()
    {

        dataManager.data.buttonAdd = buttonAdd.ToString("F0");
        dataManager.data.buttonMod = buttonMod.ToString();

    }
    */
    #endregion
}
