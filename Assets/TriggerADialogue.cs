using UnityEngine;

public class TriggerADialogue : MonoBehaviour
{


    public LevelAsset LevelAsset;


    void OnTriggerEnter()
    {
        LevelAsset.PlayDialogue(LevelAsset.EventTriggeredDialoguesList[0]);
        Destroy(gameObject);
    }




}
