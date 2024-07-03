using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Quiz", menuName = "New Quiz")]
public class QuizSO : ScriptableObject
{
    public string quizQuestion;
    public string quizAnswer;
    public string fullAnswer;
    public QuizType quizType;
    public string imagePath;
    public Sprite sprite;
}
public enum QuizType
{
    fill, picture
}
