using UnityEngine;
using Unity.UI;
using TMPro;
using BreakInfinity;

public class AddViewEffect : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    [SerializeField] private float fadeDistance;
    [SerializeField] private Vector3 targetLocation;

    private TextMeshProUGUI addViewText;

    private PostButton postButton;
    private Vector3 initialPosition;

    private float elapsedTime;

    private void Start()
    {
        addViewText = GetComponent<TextMeshProUGUI>();
        postButton = PostButton.Instance;
        targetLocation = new Vector3(transform.position.x, transform.position.y + fadeDistance, transform.position.z);
        initialPosition = transform.position;
        transform.position = initialPosition;
        SetAddViewText();
        this.gameObject.GetComponent<CanvasGroup>().LeanAlpha(0, fadeTime);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < fadeTime)
        {
            transform.position = Vector3.Lerp(initialPosition, targetLocation, elapsedTime / fadeTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetAddViewText()
    {
        BigDouble postButtonRate = postButton.buttonAdd * postButton.buttonMod;
        string postRate = postButtonRate.ToString("F0");
        addViewText.text = "+ " + postRate;
    }
}
