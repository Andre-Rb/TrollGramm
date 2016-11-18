using UnityEngine;

public class FifthDialogue : DialogueTrigger
{
    // ReSharper disable once UnusedMember.Local
    void OnTriggerEnter()
    {
        PlayDialogue();

        GetComponent<Collider>().enabled = false;

    }
}
