using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;

public class ColoringManager : SingletonMonoBehavior<ColoringManager>
{   
    [SerializeField] private Transform parent;
    [SerializeField] private ColoringUIManager coloringUIManager;
    private PictureSO currentPictureData;
    private int currentPictureIndex;
    private Process process;
    private ProcessStartInfo processInfo;
    private float loadTime;
    public static List<string> colorList = new();
    private List<GameObject> picture = new();
    public List<GameObject> picturePrefabs;
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
        loadTime = 10f;
        coloringUIManager.SetupLoadingScreen(true);
        yield return new WaitForSeconds(loadTime);
        coloringUIManager.SetupLoadingScreen(false);
        if(loadTime > 2)
            coloringUIManager.SetupTutorialScreen(true);
        yield return new WaitForSeconds(loadTime);
        if(loadTime > 2)
            coloringUIManager.SetupTutorialScreen(false);
        //picture.Add(Instantiate(Resources.Load<GameObject>("Pictures/" + currentPictureIndex), UITransform));
        picture.Add(Instantiate(picturePrefabs[currentPictureIndex], parent));
        currentPictureData = Resources.Load<PictureSO>("PictureSO/" + currentPictureIndex);
        colorList = currentPictureData.colors;
        UnityEngine.Debug.Log(colorList.Count);
        GameEvent.OnMinigameStart?.Invoke();
    }
    public void ProcessData(string sign)
    {
        if (colorList.Contains(sign))
        {
            GameEvent.OnColoring?.Invoke(sign);
            colorList.Remove(sign);
            if (colorList.Count <= 0)
                StartCoroutine(StartNewLevel());
        }
    }

    IEnumerator StartNewLevel()
    {
        yield return new WaitForSeconds(5);
        currentPictureIndex += 1;
        DestroyImmediate(picture[0]);
        picture.Clear();
        if (currentPictureIndex > 4) currentPictureIndex = 0;
        PlayerPrefs.SetInt(Constant.COLORING_LEVEL, currentPictureIndex);
        //picture.Add(Instantiate(Resources.Load<GameObject>("Pictures/" + currentPictureIndex), UITransform));
        picture.Add(Instantiate(picturePrefabs[currentPictureIndex], parent));
        currentPictureData = Resources.Load<PictureSO>("PictureSO/" + currentPictureIndex);
        colorList = currentPictureData.colors;
        GameEvent.OnMinigameStart?.Invoke();
    }
}
