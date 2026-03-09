using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
public class PostButton : MonoBehaviour, ISaveable
{
    #region VARIABLES

    public BigDouble buttonAdd;

    private DataManager dataManager;

    #endregion

    public void OnPostButtonPress()
    {
        ResourceManager.Instance.AddViews(buttonAdd);
    }

    #region MONOBEHAVIOUR FUNCTIONS

    private void Awake()
    {
        buttonAdd = new BigDouble(1);
    }

    private void Start()
    {
        dataManager = DataManager.Instance;
        dataManager.saveableObjects.Add(this);
    }

    #endregion

    #region ISAVEABLE FUNCTIONS

    public void LoadVariables()
    {

        buttonAdd = BigDouble.Parse(dataManager.data.buttonAdd);

    }

    public void SaveVariables()
    {

        dataManager.data.buttonAdd = buttonAdd.ToString("F0");

    }

    #endregion
}
