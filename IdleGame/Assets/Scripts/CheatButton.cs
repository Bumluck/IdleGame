using UnityEngine;
using BreakInfinity;

public class CheatButton : MonoBehaviour
{
    public BigDouble cheatAmount;

    private ResourceManager resourceManager;

    public void OnButtonPress()
    {
        ResourceManager.Instance.AddViews(cheatAmount);
    }
}
