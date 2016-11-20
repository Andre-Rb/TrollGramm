using UnityEngine;

public class LastRoomSwitch : Switch
{
    public LastRoomManager Manager;
    public Light Light;


    public bool isFinalActivation;
    private bool _isActivated;

    public bool IsActivated
    {
        get { return _isActivated; }
        set { _isActivated = value; }
    }

    void Activate()
    {
        GoGreen();
        IsActivated = true;
        if (!isFinalActivation)
        {
            Manager.PlayARandomLine();

            Manager.AddSwitchToActivatedOnes(this);
        }
        if (Manager.AreAllSwtichesBeenActivated && !Manager.AreAllSwtichesBeenActivatedDone)
        {
            Manager.AreAllSwtichesBeenActivatedDone = true;

            Invoke("CallForDialogue", Manager.lasttriggered.DialogueToPlay.lineclip.length);
        }
    }

    // ReSharper disable once UnusedMember.Local
    void CallForDialogue()
    {
        Manager.TriggerAllSwitchesActivatedDialogue();

    }
    public void Deactivate()
    {
        ResetColor();
        IsActivated = false;
        Manager.RemoveSwitchToActivatedOnes(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player.ToString()) && !IsActivated)
        {
            Activate();
            if (isFinalActivation)
            {
                FinalActivation();

            }
        }
    }

    public void ActivateSpotLight()
    {
        Light.gameObject.SetActive(true);

    }

    void FinalActivation()
    {

        Manager.OpenLastDoor();
        Manager.PlayVictoryDialogue();
    }

    public void SetUpForFinalActivation()
    {
        ActivateSpotLight();
        isFinalActivation = true;
    }


}