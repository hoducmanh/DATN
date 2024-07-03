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
    [SerializeField] private GameObject pausePopup;
    [SerializeField] private GameObject loadingPopup;
    [SerializeField] private GameObject tutorialPopup;
    [SerializeField] private GameObject completePopup;
    private void OnEnable()
    {
        Time.timeScale = 1f;
        StartCoroutine(DelayLoad());
    }
    public void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
    }
    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(20f);
        pauseButton.gameObject.SetActive(true);
    }
    public void SetupLoadingScreen(bool isOn)
    {
        loadingPopup.SetActive(isOn);  
    }
    public void SetupTutorialScreen(bool isOn)
    {
        tutorialPopup.SetActive(isOn); 
    }
}
