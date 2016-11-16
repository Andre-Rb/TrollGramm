using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelAsset : MonoBehaviour
{
    public SubtitlesController SubtitlesController;

    public List<Dialogue> RandomDialoguesList;
    public List<Dialogue> EventTriggeredDialoguesList;
    public AudioSource PlayerAudioSource;

    private SortedList<int, Dialogue> SortedListRdnDialogues;
    Dialogue _currentDialogue;

    private bool ableToInvokeAgain;
    public Dialogue GetRandomDialogue()
    {
        return RandomDialoguesList[Random.Range(0, RandomDialoguesList.Count)];
    }
    const float timeForDisappearing = 5;




    string firstDialogue()
    {
        PlayDialogue(EventTriggeredDialoguesList[0]);
        return null;
    }


    void Start()
    {


        //_currentDialogue = RandomDialoguesList[0];
        //PlayDialogue(_currentDialogue);
        ableToInvokeAgain = true;

        Invoke(firstDialogue(), 5);


    }


    void Update()
    {
        if (!CheckIfDialogueIsPlaying() && ableToInvokeAgain)
        {
            ableToInvokeAgain = false;
            Invoke("HideIfDoneSubsPanel", timeForDisappearing);

        }
    }

    void HideIfDoneSubsPanel()
    {
        if (!CheckIfDialogueIsPlaying())
        {
            SubtitlesController.SetActive(false);
            _currentDialogue = null;
            ableToInvokeAgain = true;

        }

    }

    private bool CheckIfDialogueIsPlaying()
    {
        return PlayerAudioSource.isPlaying;
    }

    public void PlayDialogue(Dialogue dialogue)


    {
        SubtitlesController.SetActive(true);

        PlayerAudioSource.clip = dialogue.lineclip;
        PlayerAudioSource.Play();
        SubtitlesController.speaker.text = (dialogue.speaker != "") ? dialogue.speaker : "Narrator";
        SubtitlesController.textComponent.text = dialogue.lineText;
    }
}