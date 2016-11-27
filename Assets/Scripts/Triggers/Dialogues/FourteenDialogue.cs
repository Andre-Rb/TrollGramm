public class FourteenDialogue : DialogueTrigger
{

    public FifiteenDialogue Dialogue;


    protected override void DialogueFinishedPlaying()
    {
        base.DialogueFinishedPlaying();
        Dialogue.PlayDialogue();
    }
}
