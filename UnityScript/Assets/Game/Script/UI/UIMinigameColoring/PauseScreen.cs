
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button homeButton;
    private void Awake()
    {
        resumeButton.onClick.AddListener(OnClickResumeButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }
    private void OnClickResumeButton()
    {
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnClickHomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnDestroy()
    {
        resumeButton.onClick.RemoveAllListeners();
        homeButton.onClick.RemoveAllListeners();
    }
}
