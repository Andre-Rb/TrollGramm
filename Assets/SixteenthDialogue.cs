using UnityEngine;
using System.Collections;

public class SixteenthDialogue : DialogueTrigger {

    private void OnTriggerEnter(Collider other)
    {
        PlayDialogue();
        other.enabled = false;
    }


}
