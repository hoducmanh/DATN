using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BreakTheBlockUIManager : SingletonMonoBehavior<BreakTheBlockUIManager>
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject pausePopup;
    [SerializeField] private GameObject loadingPopup;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private BreakTheBlockIngameData ingameData;
    [SerializeField] private GameObject losePopup;
    [SerializeField] private GameObject tutorialPopup;

    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnGameLose += OnGameLoseEvent;
        GameEvent.OnRestartGame += OnRestartGameEvent;
        pauseButton.onClick.AddListener(OnClickPauseButton);
    }
    public void OnObjectDestroy()
    {
        ingameData.IncreaseScore();
    }
    public void OnObjectReachVoid()
    {
        ingameData.DecreaseHealth();
    }

    private void OnGameLoseEvent()
    {
        losePopup.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void OnClickResumeButton()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    public void OnClickHomeButton()
    {
        GameEvent.OnReturnHome?.Invoke();
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetScoreAndLife()
    {
        ingameData.ResetData();
    }
    private void OnRestartGameEvent()
    {
        ResetScoreAndLife();
        losePopup.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    public void OnClickRestartButton()
    {
        GameEvent.OnRestartGame?.Invoke();
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
    public void OnMinigameStart()
    {
        StartCoroutine(DelayTime());
    }
    IEnumerator DelayTime()
    {
        Time.timeScale = 1f;
        loadingPopup.SetActive(true);
        yield return new WaitForSeconds(10f);
        loadingPopup.SetActive(false);
        tutorialPopup.SetActive(true);
        yield return new WaitForSeconds(10f);
        tutorialPopup.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        ingameUI.gameObject.SetActive(true);
        ResetScoreAndLife();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.OnGameLose -= OnGameLoseEvent;
        GameEvent.OnRestartGame -= OnRestartGameEvent;
        pauseButton.onClick.RemoveAllListeners();
    }
}
