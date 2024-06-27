using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LearningManager : SingletonMonoBehavior<LearningManager>
{
    private Process process;
    private ProcessStartInfo processInfo;
    public static LearningSO currentData;
    public static string currentSign;
    public static bool isPause;
    private bool canReceiveData;
    private int currentIndex = 0;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private List<LearningSO> datas;
    private void Start()
    {
        canReceiveData = true;
        currentData = datas[GameManager.lessonId];
        currentSign = currentData.lessonDatas[currentIndex].name;
    }
    private void OnEnable()
    {
        UnityEngine.Debug.Log("Learning start");
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
        process = Process.Start(processInfo);

#endif
    }
    IEnumerator DelayLoad()
    {
        canReceiveData = false;
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        tutorialScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        tutorialScreen.SetActive(false);
        canReceiveData = true;
        loadingScreen.SetActive(false);
    }
    public void ProcessData(string sign)
    {
        if (!canReceiveData) return;
        StartCoroutine(AnalyzeData(sign));  
        
    }
    IEnumerator AnalyzeData(string sign)
    {
        UnityEngine.Debug.Log(currentSign);
        canReceiveData = false;
        if (sign == currentSign)
        {
            LearningUIManger.Instance.SetCorrectPopup(true);
            yield return new WaitForSeconds(1f);
            LearningUIManger.Instance.SetCorrectPopup(false);
            yield return new WaitForSeconds(1f);
            currentIndex++;
            currentSign = currentData.lessonDatas[currentIndex].name;
            UnityEngine.Debug.Log(currentSign);
            GameEvent.OnCompleteLetter?.Invoke();
        }
        yield return new WaitForSeconds(1f);
        canReceiveData = true;
    }
}
