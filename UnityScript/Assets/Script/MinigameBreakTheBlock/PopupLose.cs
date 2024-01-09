using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupLose : MonoBehaviour
{
    [SerializeField] private Button replayButton;
    [SerializeField] private Button homeButton;
    private void OnEnable()
    {
        replayButton.onClick.AddListener(OnClickReplayButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }
    private void OnClickReplayButton()
    {
        GameEvent.OnRestartGame?.Invoke();
    }
    private void OnClickHomeButton()
    {
        GameEvent.OnReturnHome?.Invoke();
        SceneManager.LoadScene("MainMenu");
    }
}