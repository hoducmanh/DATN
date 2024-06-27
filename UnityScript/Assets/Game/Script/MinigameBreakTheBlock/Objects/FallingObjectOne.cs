
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectOne : FallingObject
{
    [SerializeField] private TMP_Text text;
    private KeyCode keyCode;
    //private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string chars = "ABCD";
    private void Awake()
    {
        SetupData();
        GameEvent.OnDestroyBlock += CheckReceiveData;
    }
    private void SetupData()
    {
        keyCode = GetRandomAlphabet(chars);
        text.text = keyCode.ToString();
        health = 1;
    }
    private void CheckReceiveData(string sign)
    {
        if(sign == keyCode.ToString())
        {
            DecreaseObjectHealth(health);
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.OnDestroyBlock -= CheckReceiveData;
    }
}
