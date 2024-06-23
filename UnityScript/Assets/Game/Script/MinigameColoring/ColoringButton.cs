using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoringButton : MonoBehaviour
{
    public string color;
    public Button coloringButton;
    private void OnEnable()
    {
        coloringButton.onClick.AddListener(TurnOnPopupColoring);
    }
    private void TurnOnPopupColoring()
    {
        ColoringManager.Instance.currentCheckingColor = this.color;
        ColoringUIManager.Instance.TurnOnColoringScreen(this.color);
        GameEvent.OnColoring?.Invoke(color);
    }
}
