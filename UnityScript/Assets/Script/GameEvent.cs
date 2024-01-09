
public static class GameEvent
{
    public static OnGameStart OnGameStart;
    public static OnGameLose OnGameLose;
    public static OnGameWin OnGameWin;
    public static OnLevelComplete OnLevelComplete;
    public static OnLoadHome OnLoadHome;
    public static OnGameBreakTheBlockStart OnGameBreakTheBlockStart;
    public static OnReturnHome OnReturnHome;
    public static OnColoring OnColoring;
    public static OnRestartGame OnRestartGame;
}

public delegate void OnGameStart(int gameNum);

public delegate void OnGameLose();

public delegate void OnGameWin();

public delegate void OnLevelComplete();

public delegate void OnLoadHome();

public delegate void OnGameBreakTheBlockStart();

public delegate void OnReturnHome();

public delegate void OnRestartGame();

public delegate void OnColoring(string colorName);