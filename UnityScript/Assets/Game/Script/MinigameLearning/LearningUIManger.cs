using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LearningUIManger : SingletonMonoBehavior<LearningUIManger>
{
    [SerializeField] private List<LearningSO> datas;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject correctPopup;
    private int currentIndex = 0;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        LearningManager.currentData = datas[GameManager.lessonId];
        GameEvent.onCompleteLetter += NextLetter;
    }
    void Start()
    {
        image.sprite = LearningManager.currentData.lessonDatas[currentIndex].sprite;
        text.text = LearningManager.currentData.lessonDatas[currentIndex].description;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.onCompleteLetter -= NextLetter;
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
    }
    public void SetCorrectPopup(bool appear)
    {
        correctPopup.SetActive(appear);
    }
}
