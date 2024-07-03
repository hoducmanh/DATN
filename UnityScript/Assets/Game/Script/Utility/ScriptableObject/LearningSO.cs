using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lesson", menuName = "New Lesson")]
public class LearningSO : ScriptableObject
{
    public List<LessonData> lessonDatas;
    public List<string> videoUrls;
}

[Serializable]
public class LessonData
{
    public Sprite sprite;
    public string name;
    public string description;  
}
