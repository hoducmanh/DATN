
using UnityEngine;
using UnityEngine.UI;

public class BreakTheBlockIngameData : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int life;
    public Text scoreText;    
    public Text lifeText;
    
    public void ResetData()
    {
        score = 0;
        life = 3;
        scoreText.text = "0";
        lifeText.text = "x3";
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void DecreaseHealth()
    {
        life--;
        if (life < 1) GameEvent.OnGameLose?.Invoke();
        lifeText.text = "x" + life.ToString();
    }
}
