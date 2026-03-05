using UnityEngine;
using UnityEngine.UI;
public class PostButton : MonoBehaviour
{
    public void OnPostButtonPress(int addAmount)
    {
        ResourceManager.Instance.AddViews((uint)addAmount);
    }
}
