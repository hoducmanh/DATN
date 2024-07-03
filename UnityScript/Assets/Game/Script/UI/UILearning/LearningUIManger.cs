using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningUIManger : SingletonMonoBehavior<LearningUIManger>
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button pauseButton;
    [SerializeField] private VideoController videoController;
    [SerializeField] private GameObject correctPopup;
    [SerializeField] private GameObject pausePopup;
    [SerializeField] private GameObject completePopup;
    [SerializeField] private GameObject loadingPopup;
    [SerializeField] private GameObject tutorialPopup;
    private int currentIndex = 0;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Debug.Log(loadingPopup);
        pauseButton.onClick.AddListener(OnClickPauseButton);
        GameEvent.OnCompleteLetter += NextLetter;
    }
    void Start()
    {
        image.sprite = LearningManager.currentData.lessonDatas[currentIndex].sprite;
        text.text = LearningManager.currentData.lessonDatas[currentIndex].description;
        videoController.PlayVideo(LearningManager.currentData.videoUrls[currentIndex]);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.OnCompleteLetter -= NextLetter;
    }
    private void NextLetter()
    {
        currentIndex++;
        if(currentIndex >= LearningManager.currentData.lessonDatas.Count)
        {
            PlayerPrefs.SetInt(Constant.CURRENT_LESSON, GameManager.lessonId);
            return;
        }
        image.sprite = LearningManager.currentData.lessonDatas[currentIndex].sprite;
        text.text = LearningManager.currentData.lessonDatas[currentIndex].description;
        videoController.PlayVideo(LearningManager.currentData.videoUrls[currentIndex]);
    }
    public void SetCorrectPopup(bool appear)
    {
        correctPopup.SetActive(appear);
    }
    private void OnClickPauseButton()
    {
        pausePopup.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void OnCompleteLesson()
    {
        completePopup.SetActive(true);
    }
    public void LoadNextLesson()
    {
        currentIndex = 0;
        image.sprite = LearningManager.currentData.lessonDatas[currentIndex].sprite;
        text.text = LearningManager.currentData.lessonDatas[currentIndex].description;
        videoController.PlayVideo(LearningManager.currentData.videoUrls[currentIndex]);
    }
    public void SetupLoadingPopup(bool appear)
    {
        loadingPopup.SetActive(appear);
    }
    public void SetupTutorialPopup(bool appear)
    {
        tutorialPopup.SetActive(appear);
    }
}
