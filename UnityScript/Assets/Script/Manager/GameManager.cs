
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonDontDestroy<GameManager>
{
    public string[] sceneName;
    public GameMode currentGameMode;
    public bool isModelOpen;
    protected override void Awake()
    {
        base.Awake();
        currentGameMode = GameMode.None;
        GameEvent.OnLoadHome += LoadHome;
        GameEvent.OnGameWin += OnWin;
    }
    public void LoadMiniGame(int gameNum)
    {
        SceneManager.LoadScene(sceneName[gameNum]);
        currentGameMode = (GameMode)gameNum;
        Receiver.Instance.StartNewThread();
    }
    public void LoadHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnDestroy()
    {
        GameEvent.OnLoadHome -= LoadHome;
        GameEvent.OnGameWin -= OnWin;   
    }
    private void OnWin()
    {
        Debug.Log("Win");
    }

}
public enum GameMode
{
    BreakTheBlock, Coloring, Quiz, None
}
