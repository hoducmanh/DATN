using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;

public class ColoringManager : SingletonMonoBehavior<ColoringManager>
{   
    public string currentCheckingColor;
    [SerializeField] private Transform UITransform;
    [SerializeField] private ColoringUIManager coloringUIManager;
    private PictureSO currentPictureData;
    private GameObject coloringObject;
    private int currentPictureIndex;
    private Process process;
    private ProcessStartInfo processInfo;
    private float loadTime;
    public List<string> colorList = new();
    private void OnEnable()
    {
        currentPictureIndex = PlayerPrefs.GetInt(Constant.COLORING_LEVEL, 0);
        UnityEngine.Debug.Log("Coloring start");
        StartCoroutine(DelayLoad());
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
    IEnumerator DelayLoad()
    {
        if (!GameManager.isModelOpen) loadTime = 10f;
        else loadTime = 2f;
        coloringUIManager.SetupLoadingScreen(true);
        yield return new WaitForSeconds(loadTime);
        coloringUIManager.SetupLoadingScreen(false);
        if(loadTime > 2)
            coloringUIManager.SetupTutorialScreen(true);
        yield return new WaitForSeconds(loadTime);
        if(loadTime > 2)
            coloringUIManager.SetupTutorialScreen(false);
        coloringObject = Instantiate(Resources.Load<GameObject>("Pictures/" + currentPictureIndex), UITransform);
        currentPictureData = Resources.Load<PictureSO>("PictureSO/" + currentPictureIndex);
        colorList = currentPictureData.colors;
    }
    public void ProcessData(string color)
    {
        CheckData(color);
    }
    private void CheckData(string sign)
    {
        if (colorList.Contains(sign))
        {
            GameEvent.OnColoring?.Invoke(sign);
            colorList.Remove(sign);
            if(colorList.Count <= 0)
                StartNewLevel();
        }
    }
    private void StartNewLevel()
    {
        Destroy(coloringObject);
        currentPictureIndex += 1;
        PlayerPrefs.SetInt(Constant.COLORING_LEVEL, currentPictureIndex);
        coloringObject = Instantiate(Resources.Load<GameObject>("Pictures/" + currentPictureIndex), UITransform);
        currentPictureData = Resources.Load<PictureSO>("PictureSO/" + currentPictureIndex);
        colorList = currentPictureData.colors;
    }
}
