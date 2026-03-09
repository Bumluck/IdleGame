using UnityEngine;
using UnityEngine.UI;
public class PostButton : MonoBehaviour
{

    public int buttonAdd;

    public void OnPostButtonPress()
    {
        ResourceManager.Instance.AddViews(buttonAdd);
    }
}
