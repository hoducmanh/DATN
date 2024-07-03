using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameChoosingScreen : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject prevScreen;
    [SerializeField] private Button breakTheBlockButton;
    [SerializeField] private Button coloringButton;
    [SerializeField] private Button quizzyButton;
    private void OnEnable()
    {
        breakTheBlockButton.onClick.AddListener(() => GameManager.Instance.LoadMiniGame(0));
        coloringButton.onClick.AddListener(() => GameManager.Instance.LoadMiniGame(1));
        quizzyButton.onClick.AddListener(() => GameManager.Instance.LoadMiniGame(2));
        homeButton.onClick.AddListener(Hide);
    }
    private void Hide()
    {
        prevScreen.SetActive(true);
        gameObject.SetActive(false);
       
    }
    private void OnDisable()
    {
        homeButton.onClick.RemoveAllListeners();
        breakTheBlockButton.onClick.RemoveAllListeners();
        coloringButton.onClick.RemoveAllListeners();
        quizzyButton.onClick.RemoveAllListeners();
    }
}
