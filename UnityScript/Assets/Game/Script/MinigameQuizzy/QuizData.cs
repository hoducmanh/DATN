
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizData : SingletonMonoBehavior<QuizData>
{
    
    [SerializeField] private Text quizQuestion;
    [SerializeField] private Text quizNumber;
    [SerializeField] private Image quizImage;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Text answerText;

    public QuizSO data;
    public int currentLevel;
    public string quizAnswer;
    private void OnEnable()
    {
        currentLevel = PlayerPrefs.GetInt(Constant.QUIZ_LEVEL, 1);
    }
    public void LoadData(int level)
    {
        if (data)
        {
            data = null;
            quizAnswer = null;
        }
        data = Resources.Load<QuizSO>("QuizSO/" + level);
        quizNumber.text = "Quiz " + level;
        quizAnswer = data.quizAnswer;

        if(data.quizType == QuizType.fill)
        {
            quizImage.gameObject.SetActive(false);
            quizQuestion.text = "Please choose the correct character to fill in missing part: " + data.quizQuestion; 
        }
        else if (data.quizType == QuizType.picture)
        {
            quizImage.gameObject.SetActive(true);
            quizQuestion.text = "What is this animal? ";
            quizImage.sprite = data.sprite;
        }

    }
    public void CheckAnswer(string answer)
    {
        if(answer == quizAnswer)
        {
            StartCoroutine(OnWin());
        }
    }
    IEnumerator OnWin()
    {
        SetupWinScreen();   
        yield return new WaitForSeconds(3f);
        QuizManager.Instance.isIngame = true;
        winScreen.SetActive(false);
        currentLevel++;
        PlayerPrefs.SetInt(Constant.QUIZ_LEVEL, currentLevel);
        LoadData(currentLevel);
    }
    private void SetupWinScreen()
    {
        winScreen.SetActive(true);
        answerText.text = data.fullAnswer;
        QuizManager.Instance.isIngame = false;
    }
}
