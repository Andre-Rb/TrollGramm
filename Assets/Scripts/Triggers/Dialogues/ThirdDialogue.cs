using UnityEngine;
using System.Collections;

public class ThirdDialogue : DialogueTrigger {

    public Animator doorToOpen;

    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        doorToOpen.SetTrigger(OtherAnimationParams.OpenDoor.ToString());

    }
}
