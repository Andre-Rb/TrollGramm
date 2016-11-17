using UnityEngine;


public class FirstDialogue : DialogueTrigger
{
    public SecondDialogue SecondDialogue;
    void OnTriggerEnter()
    {
        PlayDialogue();

        GetComponent<Collider>().enabled = false;

    }


    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        SecondDialogue.PlayDialogue();

    }
}
