using UnityEngine;
using System.Collections;

public class SeventhDialogue : DialogueTrigger {

    void OnTriggerEnter()
    {
        PlayDialogue();

        GetComponent<Collider>().enabled = false;

    }

}
