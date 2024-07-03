using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHint : MonoBehaviour
{
    [SerializeField] private List<ColorHintElement> elements;
    private void Awake()
    {
        GameEvent.OnMinigameStart += SetupHint;
    }
    private void SetupHint()
    {
        foreach (var element in elements)
        {
            element.gameObject.SetActive(false);
        }
        foreach (var element in elements)
        {
            if(ColoringManager.colorList.Contains(element.colorName))
                element.gameObject.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        GameEvent.OnMinigameStart -= SetupHint;
    }
}
