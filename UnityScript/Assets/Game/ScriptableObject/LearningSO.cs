using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lesson", menuName = "New Lesson")]
public class LearningSO : ScriptableObject
{
    public List<LessonData> lessonDatas;
}

[Serializable]
public class LessonData
{
    public Sprite sprite;
    public string name;
    public string description;  
}
