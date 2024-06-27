using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeColorEffect : MonoBehaviour
{
    private float time = 2;
    [SerializeField] private Color colorHex;
    [SerializeField] private string colorName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int id;
    private float speed = 0.5f;
    private void Awake()
    {
        GameEvent.OnColoring += SetColor;
    }
    private IEnumerator ChangeColor()
    {
        float tick = 0f;
        while (spriteRenderer.color != colorHex)
        {
            tick += Time.deltaTime * speed;
            spriteRenderer.color = Color.Lerp(Color.white, colorHex, tick);
            yield return null;
        }
    }
    public void SetColor(string invokedColor)
    {
        Debug.Log("here " + invokedColor);
        if(invokedColor == colorName)
        {
            StartCoroutine(ChangeColor());
        }
            
    }
    private void OnDestroy()
    {
        GameEvent.OnColoring -= SetColor;
    }
}
