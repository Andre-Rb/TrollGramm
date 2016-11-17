using UnityEngine;

namespace Assets.Scripts.Triggers.Dialogues
{
    public class FirstDialogue : DialogueTrigger
    {
        public Animator doorToOpen;

        void OnTriggerEnter()
        {
            PlayDialogue();

            GetComponent<Collider>().enabled = false;

        }

        new void DialogueFinishedPlaying()
        {
            doorToOpen.SetTrigger(OtherAnimationParams.OpenDoor.ToString());

        }

    }
}
