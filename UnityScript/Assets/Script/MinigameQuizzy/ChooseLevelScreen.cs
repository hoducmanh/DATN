using JackieSoft;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelScreen : MonoBehaviour
{
    [SerializeField] private ListView listView;
    [SerializeField] private ScrollRect scrollRect;
    private void OnEnable()
    {
        scrollRect.content.anchoredPosition = Vector2.zero;
        listView.data = new List<Cell.IData>();
        for (int i = 0; i < 10; i++)
        {
            QuizButtonElementData data = new QuizButtonElementData(i + 1);
            listView.data.Add(data);
        }
        listView.Initialize();
    }
}
