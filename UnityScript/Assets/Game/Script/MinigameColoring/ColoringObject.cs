using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringObject : SingletonMonoBehavior<ColoringObject>
{
    [SerializeField] private List<SpriteRenderer> renderers;
    public PictureSO pictureSO;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnColoring += ChangeColor;
    }
    void Start()
    {
        //LoadDataFromSO();
    }
    private void LoadDataFromSO()
    {
        for(int i = 1;i <= pictureSO.colorNum; i++)
        {
            SetColorForParts(pictureSO.pictureDatas[i]);
        }
    }
    private void SetColorForParts(PictureData data)
    {
        Color tempColor;
        ColorUtility.TryParseHtmlString(data.color, out tempColor);
        for(int i = 0;i < data.parts.Length; i++)
        {
            renderers[data.parts[i]].color = tempColor;
        }
    }
    private void ChangeColor(string colorName)
    {
        for (int i = 1; i <= pictureSO.colorNum; i++)
        {
            if(pictureSO.pictureDatas[i].color == colorName)
                SetColorForParts(pictureSO.pictureDatas[i]);
        }
    }
}
