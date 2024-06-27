using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColoringUIManager : SingletonMonoBehavior<ColoringUIManager>
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject coloringScreen;
    [SerializeField] private GameObject coloringButtons;
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private Text coloringText;

    private void OnEnable()
    {
        Time.timeScale = 1f;
        StartCoroutine(delayTime());
        //GameEvent.OnColoring?.Invoke("yellow");
    }
    public void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(10f);
        SetupUI();
    }
    private void SetupUI()
    {
        pauseButton.gameObject.SetActive(true);
        coloringButtons.gameObject.SetActive(true);
    }
    public void TurnOnColoringScreen(string color)
    {
        coloringScreen.SetActive(true);
        coloringText.text = "To color " + color + ", please make correct sign corresponding to it";
    }
    public void SetupLoadingScreen(bool isOn)
    {
        loadingScreen.SetActive(isOn);  
    }
    public void SetupTutorialScreen(bool isOn)
    {
        tutorialScreen.SetActive(isOn); 
    }
}
