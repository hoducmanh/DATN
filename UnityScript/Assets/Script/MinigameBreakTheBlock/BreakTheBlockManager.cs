
using System.Diagnostics;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class BreakTheBlockManager : SingletonMonoBehavior<BreakTheBlockManager>
{
    [SerializeField] private SpawnObject spawner;
    [SerializeField] private BreakTheBlockUIManager btbUIManager;
    Process process;
    ProcessStartInfo processInfo;
    
    private void OnEnable()
    {
        if (!GameManager.Instance.isModelOpen)
        {
            OpenFile();
            GameManager.Instance.isModelOpen = true;
        }
        btbUIManager.OnMinigameStart();
        GameEvent.OnGameLose += OnGameLoseEvent;
        GameEvent.OnRestartGame += OnRestartGameEvent; 
    }
    public void OpenFile()
    {
#if UNITY_EDITOR
        string path = System.IO.Directory.GetCurrentDirectory();
        var argument = path + "\\Assets";
        processInfo = new ProcessStartInfo()
        {
            UseShellExecute = false,
            FileName = argument + "\\sub.exe",
            CreateNoWindow = false,
            WindowStyle = ProcessWindowStyle.Normal,
            RedirectStandardOutput = true,
            Arguments = argument,
        };
        process = Process.Start(processInfo);
        UnityEngine.Debug.Log(process.Id);
#else
        string path = System.IO.Directory.GetCurrentDirectory();
        var argument = path;
        processInfo = new ProcessStartInfo()
        {
            UseShellExecute = false,
            FileName = argument + "\\sub.exe",
            CreateNoWindow = false,
            WindowStyle = ProcessWindowStyle.Normal,
            RedirectStandardOutput = true,
            Arguments = argument,
        };
        CheckFolder.Instance.textLog.text = path + "lmao";
        process = Process.Start(processInfo);

#endif
    }
    //System.Diagnostics.Process.Start("sub.exe");
    public void ProcessData(string keyCode)
    {
        DestroyObjectWithThisKey(keyCode);
    }
    private void OnDisable()
    {
        GameEvent.OnGameLose -= OnGameLoseEvent;
        GameEvent.OnRestartGame -= OnRestartGameEvent;
    }
    private void OnGameLoseEvent()
    {
        SpawnObject.Instance.StopSpawning();
    }
    private void OnRestartGameEvent()
    {
        if (SpawnObject.Instance.listObj.Count != 0)
            SpawnObject.Instance.listObj.Clear();
        SpawnObject.Instance.GameStart();
    }
    private void DestroyObjectWithThisKey(string keyCode)
    {
        for (int i = 0; i < SpawnObject.Instance.listObj.Count; i++)
        {
            if (SpawnObject.Instance.listObj[i].letter == keyCode)
            {
                FallingObject tmp = SpawnObject.Instance.listObj[i];
                SpawnObject.Instance.listObj.RemoveAt(i);
                SpawnObject.Instance.OnDestroyObject?.Invoke(keyCode);
                Destroy(tmp);
            }
        }
    }
}
