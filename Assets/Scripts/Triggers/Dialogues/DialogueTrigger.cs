
using Assets.Scripts.Triggers.Dialogues;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public SubtitlesController SubtitlesController;

    public AudioSource PlayerAudioSource;

    public Dialogue DialogueToPlay;

    //public delegate void FinishedPlayingAction();

    //public static event FinishedPlayingAction OnFinishedPlaying;


    const float timeForDisappearing = 3;


    // ReSharper disable once UnusedMember.Local
    void HideIfDoneSubsPanel()
    {
        if (!PlayerAudioSource.isPlaying)
        {

            Debug.Log("Setting off subtile UI by " + GetType().Name);
            SubtitlesController.SetActive(false);
        }
    }

    protected virtual void DialogueFinishedPlaying()
    {
        Debug.Log("Finished to play " + DialogueToPlay.lineclip + (PlayerAudioSource.isPlaying ? (" but " + PlayerAudioSource.clip + " is still playing ") : " and nothing else is playing"));

        Invoke("HideIfDoneSubsPanel", timeForDisappearing);

    }

    public void PlayDialogue(float f = 0)
    {
        SubtitlesController.SetActive(true);

        PlayerAudioSource.clip = DialogueToPlay.lineclip;
        PlayerAudioSource.Play();
        SubtitlesController.speaker.text = (DialogueToPlay.speaker != "") ? DialogueToPlay.speaker : "Narrator";
        SubtitlesController.textComponent.text = DialogueToPlay.lineText;

        float lineclipLength = DialogueToPlay.lineclip.length + f;
        Debug.Log("Starting to play " + DialogueToPlay.lineclip + " for " + lineclipLength);
        Invoke("DialogueFinishedPlaying", lineclipLength);
    }
}
