
using UnityEngine;
using UnityEngine.UI;

public class BreakTheBlockIngameData : MonoBehaviour
{
    public static BreakTheBlockIngameData Instance;
    [SerializeField] private int score;
    [SerializeField] private int life;
    public Text scoreText;    
    public Text lifeText;
    
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
    }
    public void ResetData()
    {
        score = 0;
        life = 3;
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
