using UnityEngine;
using UnityEngine.UI;
using System;

public class EffectManager : MonoBehaviour
{
    //Class that will manage certain visual effects when certain events are invoked

    private PostButton postButton;
    [SerializeField] private Canvas UI;

    [SerializeField] private GameObject AddViewEffectPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = FindAnyObjectByType<Canvas>();
        postButton = PostButton.Instance;
        postButton.postButtonPressed += SpawnPostButtonAdd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPostButtonAdd()
    {
        AddViewEffect spawned = Instantiate(AddViewEffectPrefab,UI.transform).GetComponent<AddViewEffect>();
    }
}
