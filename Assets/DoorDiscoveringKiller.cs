using UnityEngine;

public class DoorDiscoveringKiller : PlayerKiller
{
    public string DeathMessage;
    public GameObject WallToMakeVanish;
    public GameObject LightToSwitchOn;
    public SecondDoor DoorToShut;
    public Canvas CanvasToEnable;
    public FourthDialogue FourthDialogue;
    public FifthDialogue FifthDialogue;
    public Switch Switch;

    protected override void SetMessage()
    {
        base.SetMessage();
        text.text = DeathMessage + touchePourRespawnMsg;
    }

    protected new void OnCollisionEnter(Collision other)
    {

        Debug.Log("Collided with child (well that's sound bad)");
        base.OnCollisionEnter(other);
        WallToMakeVanish.SetActive(false);
        CanvasToEnable.gameObject.SetActive(true); ;
        LightToSwitchOn.SetActive(true);
        player.DialogueToPlayAfterRespawn = FourthDialogue;
        FifthDialogue.GetComponent<Collider>().enabled = true;
        
        DoorToShut.CloseDoor();



        //TODO voir si on autorise de sauter plusieurs fois ( reset le dialogue)
    }


}