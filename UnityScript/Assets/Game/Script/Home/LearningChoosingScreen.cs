
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearningChoosingScreen : MonoBehaviour
{
    [SerializeField] private GameObject prevScreen;
    [SerializeField] private List<Button> buttons;
    [SerializeField] private List<int> lessonIDs;
    private void Awake()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int id = i;
            buttons[i].onClick.AddListener(() =>
            {
                GameManager.lessonId = lessonIDs[id];
                SceneManager.LoadScene("Learning");
                GameManager.currentGameMode = (GameMode)3;
                Receiver.Instance.StartNewThread();
            });
        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveAllListeners();    
        }
    }
}
