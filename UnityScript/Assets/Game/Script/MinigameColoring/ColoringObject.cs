using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringObject : SingletonMonoBehavior<ColoringObject>
{
    [SerializeField] private List<string> listColor;
    public PictureSO pictureSO;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnColoring += FinishParts;
    }
    public void FinishParts(string sign)
    {
        listColor.RemoveAll(str => str == sign);
        if (listColor.Count <= 0) GameEvent.OnLevelComplete?.Invoke();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameEvent.OnColoring -= FinishParts;
    }
}
