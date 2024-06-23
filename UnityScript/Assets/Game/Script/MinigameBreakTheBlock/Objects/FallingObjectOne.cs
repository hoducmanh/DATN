using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObjectOne : FallingObject
{
    [SerializeField] private Text text;
    private KeyCode keyCode;
    private string chars = "ABCD";
    private void Awake()
    {
        SetupData();
    }
    private void SetupData()
    {
        keyCode = GetRandomAlphabet(chars);
        text.text = keyCode.ToString();
        health = 1;
    }
    
}
