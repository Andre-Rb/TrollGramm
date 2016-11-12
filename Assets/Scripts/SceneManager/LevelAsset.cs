using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelAsset : MonoBehaviour
{



    public List<Dialogue> RandomDialoguesList;
    public List<Dialogue> EventTriggeredDialoguesList;
    private SortedList<int, Dialogue> SortedListRdnDialogues;

    Dialogue GetRandomDialogue()
    {
        return RandomDialoguesList[Random.Range(0, RandomDialoguesList.Count)];
    }


    void Start()
    {
        for (int index = 0; index < RandomDialoguesList.Count; index++)
        {
            Dialogue dialogue = RandomDialoguesList[index];
            SortedListRdnDialogues.Add(index, dialogue);

        }

        foreach (KeyValuePair<int, Dialogue> sortedListRdnDialogue in SortedListRdnDialogues)
        {
            Debug.Log("Key : " + sortedListRdnDialogue.Key + "  -  Value : " + sortedListRdnDialogue.Value);
        }
    }
}
