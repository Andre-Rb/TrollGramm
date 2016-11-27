
using UnityEngine;
// ReSharper disable once CheckNamespace

public class NineteenthDialogue :  DialogueTrigger{

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
