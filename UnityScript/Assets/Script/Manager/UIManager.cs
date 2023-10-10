using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject deleteBarrier;
    [SerializeField] private GameObject modeChoosingScreen;
    [SerializeField] private Text score;
    public void OnclickPlayButton()
    {
        mainMenu.SetActive(false); 
        modeChoosingScreen.SetActive(true);
    }
    public void OnClickEasyModeButton()
    {
        SetIngameScreen();
        if (Spawner.Instance.isIngame)
        {
            StartCoroutine(Spawner.Instance.spawnObjectEasyMode());
        }

    }
    public void OnClickMediumModeButton()
    {
        SetIngameScreen();
        if (Spawner.Instance.isIngame)
        {
            StartCoroutine(Spawner.Instance.spawnObjectMediumMode());
        }
    }
    public void OnClickHardModeButton()
    {
        SetIngameScreen();
        if (Spawner.Instance.isIngame)
        {
            StartCoroutine(Spawner.Instance.spawnObjectHardMode());
        }
    }
    public void OnclickPauseButton()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnclickResumeButton()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;

    }

    public void OnclickReturnToMainMenuButton()
    {

        pauseScreen.SetActive(false);
        spawner.SetActive(false);
        ingameUI.SetActive(false);
        deleteBarrier.SetActive(false);
        mainMenu.SetActive(true);
        Spawner.Instance.isIngame = false;
    }
    private void SetIngameScreen()
    {
        modeChoosingScreen.SetActive(false);
        Spawner.Instance.isIngame = true;
        ingameUI.SetActive(true);
        deleteBarrier.SetActive(true);
        spawner.SetActive(true);
    }
    public void OnClickReturnButtonInChoosingScreen()
    {
        mainMenu.SetActive(true);
        modeChoosingScreen.SetActive(false);
    }
}
