
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class BreakTheBlockManager : SingletonMonoBehavior<BreakTheBlockManager>
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private BreakTheBlockUIManager btbUIManager;
    private Process process;
    private ProcessStartInfo processInfo;
    
    private void OnEnable()
    {
        if (!GameManager.isModelOpen)
        {
            OpenFile();
            GameManager.isModelOpen = true;
        }
        StartCoroutine(DelayLoad());
        btbUIManager.OnMinigameStart();
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
        process = Process.Start(processInfo);

#endif
    }
    //System.Diagnostics.Process.Start("sub.exe");
    public void ProcessData(string sign)
    {
        GameEvent.OnDestroyBlock?.Invoke(sign);
    }
    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(20f);
        spawner.GameStart();
    }
}
