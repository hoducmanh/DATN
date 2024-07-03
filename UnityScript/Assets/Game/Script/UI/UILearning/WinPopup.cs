
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
    [SerializeField] private Button nextLessonButton;
    [SerializeField] private Button homeButton;
    private void Awake()
    {
        nextLessonButton.onClick.AddListener(OnClickNextLessonButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }
    private void OnClickNextLessonButton()
    {
        LearningManager.Instance.LoadNextLesson();
        gameObject.SetActive(false);
    }
    private void OnClickHomeButton()
    {
        GameEvent.OnReturnHome?.Invoke();
        SceneManager.LoadScene("MainMenu");
    }
    private void OnDestroy()
    {
        nextLessonButton.onClick.RemoveAllListeners();
        homeButton.onClick.RemoveAllListeners();
    }
}
