
using UnityEngine;

namespace Assets.Scripts.Triggers.Dialogues
{
    public class DialogueTrigger : MonoBehaviour
    {
        public SubtitlesController SubtitlesController;

        public AudioSource PlayerAudioSource;

        public Dialogue DialogueToPlay;

        //public delegate void FinishedPlayingAction();

        //public static event FinishedPlayingAction OnFinishedPlaying;


        const float timeForDisappearing = 5;


        // ReSharper disable once UnusedMember.Local
        void HideIfDoneSubsPanel()
        {
            SubtitlesController.SetActive(false);
        }

        // ReSharper disable once UnusedMember.Local
        protected void  DialogueFinishedPlaying()
        {
            //if (OnFinishedPlaying != null) OnFinishedPlaying();
        }

        public void PlayDialogue()
        {
            SubtitlesController.SetActive(true);

            PlayerAudioSource.clip = DialogueToPlay.lineclip;
            PlayerAudioSource.Play();
            SubtitlesController.speaker.text = (DialogueToPlay.speaker != "") ? DialogueToPlay.speaker : "Narrator";
            SubtitlesController.textComponent.text = DialogueToPlay.lineText;

            Invoke("HideIfDoneSubsPanel", DialogueToPlay.lineclip.length + timeForDisappearing);
            Invoke("DialogueFinishedPlaying", DialogueToPlay.lineclip.length);
        }
    }
}