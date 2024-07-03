using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningLoadingPopup : MonoBehaviour
{
    [SerializeField] private Text lessonText;
    private void OnEnable()
    {
        var num = GameManager.lessonId + 1;
        lessonText.text = "Lesson " + num.ToString();
    }
}
