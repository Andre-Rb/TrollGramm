using UnityEngine;

public class TwentythDialogue : DialogueTrigger {

    // ReSharper disable once UnusedMember.Local
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player.ToString()))
        {
            PlayDialogue();
            GetComponent<Collider>().enabled = false;
        }
    }
}
