using UnityEngine;
using System.Collections;

public class SixthDialogue : DialogueTrigger
{


    // ReSharper disable once UnusedMember.Local
    void OnTriggerEnter()
    {
        PlayDialogue();

        GetComponent<Collider>().enabled = false;

    }
}
