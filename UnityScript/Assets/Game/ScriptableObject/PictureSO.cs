using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Picture", menuName = "New Picture")]
public class PictureSO : ScriptableObject
{
    public int colorNum;
    public PictureData[] pictureDatas;
}
[System.Serializable]
public class PictureData
{
    public int[] parts;
    public string color;
    public string colorHex;
}
