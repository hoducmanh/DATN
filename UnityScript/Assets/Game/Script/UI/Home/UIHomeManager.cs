
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject modeChoosingScreen;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private GameObject collectionScreen;
    [SerializeField] private GameObject achievementScreen;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button achievementButton;
    public void OnClickCollectionButton()
    {
        collectionScreen.SetActive(true);
    }
    public void OnClickAchievementButton()
    {
        achievementScreen.SetActive(true);
    }
    public void OnclickStartButton()
    {
        mainMenu.SetActive(false); 
        modeChoosingScreen.SetActive(true);
    }
    public void OnClickChooseLevel()
    {
        modeChoosingScreen.SetActive(false);
    }
    public void OnClickReturnButtonInChoosingScreen()
    {
        mainMenu.SetActive(true);
        modeChoosingScreen.SetActive(false);
    }
    public void OnClickSettingButton()
    {
        settingScreen.SetActive(true);
    }
    public void OnClickExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
