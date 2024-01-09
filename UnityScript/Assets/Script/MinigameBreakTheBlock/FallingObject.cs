using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FallingObject : MonoBehaviour
{
    public TMP_Text objText;
    public string letter;
    private KeyCode keyCode;
    //private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string chars = "ABCD";
    void Start()
    {
        keyCode = GetRandomAlphabet();
        letter = keyCode.ToString();
        objText.text = letter;
        SpawnObject.Instance.OnDestroyObject += OnDestroyThisObject;
        GameEvent.OnRestartGame += OnRestartGameEvent;
    }
    private void Update()
    {
        if(SpawnObject.Instance.isIngame == false)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        SpawnObject.Instance.OnDestroyObject -= OnDestroyThisObject;
        GameEvent.OnRestartGame -= OnRestartGameEvent;
    }
    public KeyCode GetRandomAlphabet()
    {
        int index = UnityEngine.Random.Range(0, chars.Length);
        string str = chars[index].ToString();
        KeyCode tmpKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), str);
        return tmpKeyCode;
    }

    private void OnDestroyThisObject(string keyCode)
    {
        if (keyCode == letter)
        {
            Destroy(gameObject);
            BreakTheBlockIngameData.Instance.IncreaseScore();
        }
    }
    private void OnRestartGameEvent()
    {
        Destroy(gameObject);
    }
    
}

