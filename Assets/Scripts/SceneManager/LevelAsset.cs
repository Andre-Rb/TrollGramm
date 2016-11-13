using System.Collections.Generic;
using System.Linq;
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


    void Start()
    {


        _currentDialogue = RandomDialoguesList[0];
        PlayDialogue(_currentDialogue);
        ableToInvokeAgain = true;
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
        Debug.Log(PlayerAudioSource.isPlaying);
        return PlayerAudioSource.isPlaying;
    }

    void PlayDialogue(Dialogue dialogue)


    {
        SubtitlesController.SetActive(true);

        PlayerAudioSource.clip = dialogue.lineclip;
        PlayerAudioSource.Play();
        Debug.Log("Loaded a clip from " + dialogue.name);
        SubtitlesController.speaker = (dialogue.speaker != null) ? dialogue.speaker : "Narrator";
        SubtitlesController.textComponent.text = dialogue.lineText;
    }
}