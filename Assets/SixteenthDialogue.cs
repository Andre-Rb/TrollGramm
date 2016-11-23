using UnityEngine;
using System.Collections;

public class SixteenthDialogue : DialogueTrigger {

    private void OnTriggerEnter(Collider other)
    {
        PlayDialogue();
        gameObject.GetComponent<Collider>().enabled = false;
    }


}
