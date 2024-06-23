
using UnityEngine;
using UnityEngine.UI;

public class ModeChoosingScreen : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button learnButton;
    [SerializeField] private Button minigameButton;
    [SerializeField] private GameObject homeScreen;
    [SerializeField] private GameObject learnScreen;
    [SerializeField] private GameObject minigameScreen;
    private void Awake()
    {
        homeButton.onClick.AddListener(OnClickHomeButton);
        learnButton.onClick.AddListener(OnClickLearnButton);
        minigameButton.onClick.AddListener(OnClickMinigameButton);
    }
    private void OnClickHomeButton()
    {
        homeScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnClickLearnButton()
    {
        learnScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnClickMinigameButton()
    {
        minigameScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        homeButton.onClick.RemoveAllListeners();
        learnButton.onClick.RemoveAllListeners();
        minigameButton.onClick.RemoveAllListeners();
    }
}
