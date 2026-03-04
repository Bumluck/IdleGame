using UnityEngine;
using UnityEngine.UI;
public class PostButton : MonoBehaviour
{

    int addAmount;
    
    public void OnPostButtonPress()
    {
        ResourceManager.Instance.AddViews(addAmount);
    }
}
