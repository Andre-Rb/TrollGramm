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

    public Dialogue GetRandomDialogue()
    {
        return RandomDialoguesList[Random.Range(0, RandomDialoguesList.Count)];
    }


    void Start()
    {
        //for (int index = 0; index < RandomDialoguesList.Count; index++)
        //{
        //    Dialogue dialogue = GetRandomDialogue();
        //    SortedListRdnDialogues.Add(index, dialogue);

        //}

        //foreach (KeyValuePair<int, Dialogue> sortedListRdnDialogue in SortedListRdnDialogues)
        //{
        //    Debug.Log("Key : " + sortedListRdnDialogue.Key + "  -  Value : " + sortedListRdnDialogue.Value);
        //}

        PlayDialogue(RandomDialoguesList[0]);
    }


    void PlayDialogue(Dialogue dialogue)
    {
        PlayerAudioSource.clip = dialogue.lineclip;
        SubtitlesController.speaker = (dialogue.speaker != null) ? dialogue.speaker : "Narrator";
        SubtitlesController.textComponent.text = dialogue.lineText;
    }
}
