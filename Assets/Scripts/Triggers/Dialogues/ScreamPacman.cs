using UnityEngine;
using System.Collections;

public class ScreamPacman : DialogueTrigger
{
    public ThirdteenthDialogue Dialogue;
    Persistance Persistance;

    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        PlayerAudioSource.volume = 1f;

        Dialogue.PlayDialogue();

    }


    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        PlayerAudioSource.volume = 0.3f;
        Persistance = FindObjectOfType<Persistance>();

        if (!Persistance.AlreadyDiedScene02)
            PlayDialogue();
    }
}
