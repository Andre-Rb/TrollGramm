using UnityEngine;
using System.Collections;

public class EighthDialogue : DialogueTrigger
{

    void OnTriggerEnter()
    {
        PlayDialogue();

        GetComponent<Collider>().enabled = false;

    }

}
