using JackieSoft;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButtonElementData : Cell.Data<QuizButtonElement>
{
    int level;
    public QuizButtonElementData(int level)
    {
        this.level = level;
    }

    protected override void SetUp(QuizButtonElement cellView)
    {
        var currentQuizLevel = PlayerPrefs.GetInt(Constant.QUIZ_LEVEL, 1);
        cellView.button.onClick.RemoveAllListeners();
        if (level > currentQuizLevel)
        {
            cellView.SetLock();
        }
        else
        {
            cellView.Unlock();
            cellView.button.onClick.AddListener(ShowQuizScreen);
            cellView.levelText.text = level.ToString();
        }      
    }
    private void ShowQuizScreen()
    {
        QuizUIManager.Instance.SetupIngameScreen(true);
        QuizManager.Instance.isIngame = true;
        QuizData.Instance.LoadData(level);
    }
}
