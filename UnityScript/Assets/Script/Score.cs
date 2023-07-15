using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text healthText;
    private int health = 3;
    void Update()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "egg")
        {
            Destroy(target.gameObject);
            score++;
        }
        if (target.tag == "goldenEgg")
        {
            Destroy(target.gameObject);
            score+=10;
        }
        if(target.tag == "bomb")
        {
            Destroy(target.gameObject);
            health--;
            if(health <= 0)
            {
                SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
            }
        }

    }
}
