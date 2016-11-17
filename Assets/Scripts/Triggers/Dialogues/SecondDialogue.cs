using UnityEngine;

public class SecondDialogue : DialogueTrigger
{
    public ThirdDialogue ThirdDialogue;


    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        ThirdDialogue.PlayDialogue();
    }
}