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
    [SerializeField] private Text score;
    public void OnclickPlayButton()
    {
        Spawner.Instance.isIngame = true;
        mainMenu.SetActive(false);
        ingameUI.SetActive(true);
        deleteBarrier.SetActive(true);
        spawner.SetActive(true);
        if (Spawner.Instance.isIngame)
        {
            StartCoroutine(Spawner.Instance.spawnObject());
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
}
