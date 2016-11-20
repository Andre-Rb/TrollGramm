public class EleventhDialogue : DialogueTrigger
{
    private LastRoomManager _manager;


    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        _manager = GetComponent<LastRoomManager>();
    }

    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();

        _manager.ShowRndRightSwitch();
    }
}
