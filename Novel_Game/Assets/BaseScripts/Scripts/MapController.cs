using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;


    private void Start()
    {
        button2.onClick.AddListener(MapActivator);
    }

    public void MapActivator() => button3.interactable = true;

    public void MapRemover() => button2.onClick.RemoveListener(MapActivator);

}
