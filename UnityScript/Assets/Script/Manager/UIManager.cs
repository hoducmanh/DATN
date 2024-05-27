using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehavior<UIManager>
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject modeChoosingScreen;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private GameObject collectionScreen;
    [SerializeField] private GameObject achievementScreen;
    [SerializeField] private Button breakTheBlockButton;
    [SerializeField] private Button coloringButton;
    [SerializeField] private Button quizzyButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button achievementButton;
    [SerializeField] private Button collectionButton;
    private void OnEnable()
    {
        breakTheBlockButton.onClick.AddListener(OnClickBreakTheBlockButton);
        coloringButton.onClick.AddListener(OnClickColoringButton);
        quizzyButton.onClick.AddListener(OnClickQuizzyButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        achievementButton.onClick.AddListener(OnClickAchievementButton);
        collectionButton.onClick.AddListener(OnClickCollectionButton);
    }
    private void OnClickCollectionButton()
    {
        collectionScreen.SetActive(true);
    }
    private void OnClickAchievementButton()
    {
        achievementScreen.SetActive(true);
    }
    private void OnClickBreakTheBlockButton()
    {
        GameManager.Instance.LoadMiniGame(0);
    }
    private void OnClickColoringButton()
    {
        GameManager.Instance.LoadMiniGame(1);
    }
    private void OnClickQuizzyButton()
    {
        GameManager.Instance.LoadMiniGame(2);
    }
    public void OnclickPlayButton()
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
