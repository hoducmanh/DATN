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
    [SerializeField] private Button breakTheBlockButton;
    [SerializeField] private Button coloringButton;
    [SerializeField] private Button quizzyButton;
    [SerializeField] private Button exitButton;
    private void OnEnable()
    {
        breakTheBlockButton.onClick.AddListener(OnClickBreakTheBlockButton);
        coloringButton.onClick.AddListener(OnClickColoringButton);
        quizzyButton.onClick.AddListener(OnClickQuizzyButton);
        exitButton.onClick.AddListener(OnClickExitButton);
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
