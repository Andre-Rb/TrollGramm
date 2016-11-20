using UnityEngine;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
public class LastRoomManager : MonoBehaviour
{
    public List<DialogueTrigger> DialogueTriggers;
    public List<LastRoomSwitch> _lastRoomSwitches;
    public DialogueTrigger lasttriggered;
    public ThirdDoor ThirdDoor;


    private List<LastRoomSwitch> _activatedLastRoomSwitches;
    public bool AreAllSwtichesBeenActivated;
    public bool AreAllSwtichesBeenActivatedDone = false;

    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        _activatedLastRoomSwitches = new List<LastRoomSwitch>();
    }

    public void AddSwitchToActivatedOnes(LastRoomSwitch lastRoomSwitch)
    {
        if (!_activatedLastRoomSwitches.Contains(lastRoomSwitch))
        {
            _activatedLastRoomSwitches.Add(lastRoomSwitch);
        }
        if (_activatedLastRoomSwitches.Count == _lastRoomSwitches.Count)
        {
            AreAllSwtichesBeenActivated = true;
        }
    }

    public void RemoveSwitchToActivatedOnes(LastRoomSwitch lastRoomSwitch)
    {
        _activatedLastRoomSwitches.Remove(lastRoomSwitch);
    }


    public void TriggerAllSwitchesActivatedDialogue()
    {
        GetComponent<TenthDialogue>().PlayDialogue();
    }


    public void PlayARandomLine()
    {
        int rnd = Random.Range(0, DialogueTriggers.Count);

        if (lasttriggered != null)
        {
            while (DialogueTriggers[rnd] == lasttriggered)
            {
                rnd = Random.Range(0, DialogueTriggers.Count);
            }
            lasttriggered = DialogueTriggers[rnd];

        }
        else
        {
            //Force playing 9a first

            lasttriggered = GetComponent<Ninth_ADialogue>();

        }
        lasttriggered.PlayDialogue();
    }

    public void ShowRndRightSwitch()
    {
        int rnd = Random.Range(0, _lastRoomSwitches.Count);
        foreach (LastRoomSwitch aSwitch in _lastRoomSwitches)
        {
            aSwitch.Deactivate();
        }
        _lastRoomSwitches[rnd].SetUpForFinalActivation();
    }

    public void OpenLastDoor()
    {
        ThirdDoor.OpenDoor();
    }

    public void PlayVictoryDialogue()
    {
        GetComponent<TwelvethDialogue>().PlayDialogue();
    }
}