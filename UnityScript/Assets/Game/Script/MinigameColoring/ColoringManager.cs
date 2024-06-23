using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ColoringManager : SingletonMonoBehavior<ColoringManager>
{
    Process process;
    ProcessStartInfo processInfo;
    private int currentPicture;
    private GameObject coloringObject;
    public string currentCheckingColor;
    private void OnEnable()
    {
        currentPicture = PlayerPrefs.GetInt(Constant.COLORING_LEVEL, 1);
        UnityEngine.Debug.Log("Coloring start");
        if (!GameManager.isModelOpen)
        {
            OpenFile();
            GameManager.isModelOpen = true;
        }
        StartCoroutine(DelayLoad());

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
    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(10.1f);
        coloringObject = Instantiate(Resources.Load<GameObject>("Pictures/" + 1));
    }
    private void DoColor(string color)
    {
        GameEvent.OnColoring?.Invoke(color);
    }
    public void ProcessData(string color)
    {
        DoColor(color);
    }
}
