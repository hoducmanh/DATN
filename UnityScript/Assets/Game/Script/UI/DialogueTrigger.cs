using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string id;
    public Dialogue dialogue;
    private void Awake()
    {
        GameEvent.OnStartDialogue += TriggerDialogue;
    }
    private void TriggerDialogue(string id)
    {
        if(id == this.id)
            DialogueManager.Instance.StartDialogue(dialogue);
    }
}
[Serializable]
public class DialogueCharacter
{
    public String name;
    public Sprite icon;
}

[Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new();
}