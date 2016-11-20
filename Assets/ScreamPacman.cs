using UnityEngine;
using System.Collections;

public class ScreamPacman : DialogueTrigger
{
    public  ThirdteenthDialogue Dialogue;

    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        Dialogue.PlayDialogue();

    }


    void Start()
    {
        PlayDialogue();
    }
}
