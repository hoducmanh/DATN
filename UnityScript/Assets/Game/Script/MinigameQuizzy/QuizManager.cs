using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QuizManager : SingletonMonoBehavior<QuizManager>
{
    Process process;
    ProcessStartInfo processInfo;
    public bool isIngame;
    public void ProcessData(string answer)
    {
        if(isIngame)
            QuizData.Instance.CheckAnswer(answer);  
    }
    private void OnEnable()
    {
        if (!GameManager.isModelOpen)
        {
            OpenFile();
            GameManager.isModelOpen = true;
        }
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
}
