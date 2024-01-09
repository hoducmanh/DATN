using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PopupDisableInput : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject.FindObjectOfType<InputHandler>()?.BlockInput(gameObject.name);   
    }

    private void OnDisable()
    {
        GameObject.FindObjectOfType<InputHandler>()?.UnblockInput(gameObject.name);
    }
}