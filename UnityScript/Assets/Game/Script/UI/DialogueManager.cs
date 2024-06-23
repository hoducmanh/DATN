using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : SingletonMonoBehavior<DialogueManager>
{
    public Image characterIcon;
    public TMP_Text characterName;
    public TMP_Text dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isActive;
    public float typingSpeed = 0.2f;
    public Animator animator;

    public void StartDialogue(Dialogue dialogue)
    {
        isActive = true;
        animator.Play("show");
        lines.Clear();
        foreach (var dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);    
        }

    }
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isActive = false;
        animator.Play("hide");
    }
}
