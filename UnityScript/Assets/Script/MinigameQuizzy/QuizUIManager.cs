using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizUIManager : SingletonMonoBehavior<QuizUIManager>
{
    public GameObject quizScreen;
    public GameObject chooseLevelScreen;
    public GameObject pauseScreen;
    
    protected override void Awake()
    {
        base.Awake();
        SetupIngameScreen(false);

    }
    public void SetupIngameScreen(bool isIngame)
    {
        quizScreen.SetActive(isIngame);
        chooseLevelScreen.SetActive(!isIngame);
    }
    
}
