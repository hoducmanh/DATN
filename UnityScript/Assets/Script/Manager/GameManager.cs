using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Action<string> destroyObjectWithThisKey;
    
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
        destroyObjectWithThisKey += DestroyObjectWithThisKey;
    }
    private void Start()
    {

        OpenFile();
        

    }
    public void OpenFile()
    {
        // Create a new process instance
        var argument = "C:\\Manh\\Thuc_tap\\BTVN\\game\\Project_2\\Assets" ;
        var processInfo = new ProcessStartInfo()
        {
            UseShellExecute = false,
            FileName = "C:\\Manh\\Thuc_tap\\BTVN\\game\\Project_2\\Assets\\sub.exe",
            CreateNoWindow = false,
            WindowStyle = ProcessWindowStyle.Normal,
            RedirectStandardOutput = true,
            Arguments = argument,
        };

        // Provide the path to the .exe file as the FileName property
        //Process process = new Process();
        //process.StartInfo.FileName = "C:\\Manh\\Thuc_tap\\BTVN\\game\\Project_2\\Assets\\sub.exe";
        //process.StartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
        // Start the process
        
        
        var process = Process.Start(processInfo);

    }
    public void OnPressKey(string keyCode)
    {
        Spawner.Instance.OnDestroyObject?.Invoke(keyCode);
    }

    public void DestroyObjectWithThisKey(string keyCode)
    {
        for(int i = 0; i < Spawner.Instance.listObj.Count; i++)
        {
            if (Spawner.Instance.listObj[i].letter == keyCode)
            {
                FallingObject tmp = Spawner.Instance.listObj[i];
                Spawner.Instance.listObj.RemoveAt(i);
                Destroy(tmp);
            }
        }
    }

    private void OnDestroy()
    {
        destroyObjectWithThisKey -= DestroyObjectWithThisKey;
    }
    public static void StartApplication(string applicationName, string argument = "", bool useShellExecute = true, bool createNoWindow = false)
    {
        Process task = new Process
        {
            StartInfo =
    {
      UseShellExecute = useShellExecute,
      FileName = applicationName,
      Arguments = argument,
      CreateNoWindow = createNoWindow
    }
        };

        task.Start();
    }
}
