using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public Action<KeyCode> destroyObjectWithThisKey;
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

    private void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    KeyCode keyPressed = GetKeyPressed();
        //    Debug.Log("Pressed key: " + keyPressed);
        //    OnPressKey(keyPressed);
        //}
        //Debug.Log(Receiver.Instance.receivedLetter);

        //if(Receiver.Instance.receivedLetter != null)
        //{
        //    letter = Receiver.Instance.receivedLetter;
        //}

        
    }

    //private KeyCode GetKeyPressed()
    //{
    //    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
    //    {
    //        if (Input.GetKeyDown(keyCode))
    //        {
    //            return keyCode;
    //        }
    //    }
    //    return KeyCode.None;
    //}
    //public void OnPressKey(KeyCode keyCode)
    //{
    //    //if (Input.anyKey)
    //    //{
    //    //KeyCode keyPressed = Event.current.keyCode;

    //    //string keyString = keyPressed.ToString();
    //    destroyObjectWithThisKey?.Invoke(keyCode);
    //    //}
    //}

    public void OnPressKey(string keyCode)
    {
        Spawner.Instance.OnDestroyObject?.Invoke(keyCode);
        //destroyObjectWithThisKey?.Invoke(keyCode);
    }

    public void DestroyObjectWithThisKey(string keyCode)
    {
        Debug.Log("here");
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
}
