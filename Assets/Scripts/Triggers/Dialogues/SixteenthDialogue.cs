using UnityEngine;

// ReSharper disable once CheckNamespace
public class SixteenthDialogue : DialogueTrigger {

    // ReSharper disable once UnusedMember.Local
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player.ToString()))
        {
            PlayDialogue();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }


}
