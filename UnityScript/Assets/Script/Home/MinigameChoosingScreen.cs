using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameChoosingScreen : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject miniChoosingScreen;
    [SerializeField] private GameObject mainMenu;
    private void OnEnable()
    {
        
        homeButton.onClick.AddListener(Hide);
    }
    private void Hide()
    {
        miniChoosingScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
    private void OnDisable()
    {
        homeButton.onClick.RemoveAllListeners();
    }
}
