using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    [SerializeField] private int score;
    [SerializeField] private int health;
    public TMP_Text scoreText;    
    public TMP_Text healthText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void DecreaseHealth()
    {
        health--;
        healthText.text = health.ToString();
    }
}
