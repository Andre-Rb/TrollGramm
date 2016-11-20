using UnityEngine;
using System.Collections;

public class ScreamPacman : DialogueTrigger
{
    public ThirdteenthDialogue Dialogue;
     Persistance Persistance;

    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        Dialogue.PlayDialogue();

    }


    void Start()
    {

        Persistance = FindObjectOfType<Persistance>();

        if (!Persistance.AlreadyDiedScene02)
            PlayDialogue();
    }
}
