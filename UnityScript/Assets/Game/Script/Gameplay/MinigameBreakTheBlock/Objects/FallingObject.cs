
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class FallingObject : MonoBehaviour
{
    [SerializeField] protected List<string> letter = new();
    [SerializeField] protected int health;
    [SerializeField] protected GameObject effect;
    [SerializeField] protected GameObject sprite;
    //private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private void Start()
    {
        GameEvent.OnRestartGame += OnRestartGameEvent;
    }
    protected virtual void OnDestroy()
    {
        GameEvent.OnRestartGame -= OnRestartGameEvent;
    }
    protected KeyCode GetRandomAlphabet(string characterList)
    {
        int index = UnityEngine.Random.Range(0, characterList.Length);
        string str = characterList[index].ToString();
        KeyCode tmpKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), str);
        return tmpKeyCode;
    }
    protected void DecreaseObjectHealth(int health)
    {
        health -= 1;
        if(health <= 0)
            StartCoroutine(DestroyThisObject());

    }
    IEnumerator DestroyThisObject()
    {
        BreakTheBlockUIManager.Instance.OnObjectDestroy();
        effect.SetActive(true);
        sprite.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        
    }
    private void OnRestartGameEvent()
    {
        Destroy(gameObject);
    }
    
}

