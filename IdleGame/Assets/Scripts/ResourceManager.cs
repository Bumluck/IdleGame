using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    #region VARIABLES

    private int viewModifier;
    private string views;

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

    }

    //-----------------------------//
    public void AddViews(int _views)
    //-----------------------------//
    {
        views += _views;
    }

    #endregion

    #region UI FUNCTIONS



    #endregion

}
