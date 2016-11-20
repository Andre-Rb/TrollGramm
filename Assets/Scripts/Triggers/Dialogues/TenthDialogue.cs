using UnityEngine;

public class TenthDialogue : DialogueTrigger {

    public EleventhDialogue _eleventhDialogue;


    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        _eleventhDialogue.PlayDialogue();

    }
}
