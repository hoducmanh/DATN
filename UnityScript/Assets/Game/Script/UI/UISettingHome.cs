using UnityEngine;
using UnityEngine.UI;

public class UISettingHome : MonoBehaviour
{
    [SerializeField] private Button bClose;
    [SerializeField] private Slider sSound;
    [SerializeField] private Slider sMusic;
    [SerializeField] private Button tutorialButton;


    private void Awake()
    {
        bClose.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        tutorialButton.onClick.AddListener(OnClickTutorialButton);
    }
    private void OnClickTutorialButton()
    {
        Application.OpenURL("https://en.wikipedia.org/wiki/Sign_language");
    }
    private void OnDestroy()
    {
        bClose.onClick.RemoveAllListeners();
        tutorialButton.onClick.RemoveAllListeners();
    }
}
