using UnityEngine;

public class DoorDiscoveringKiller : PlayerKiller
{
    public string DeathMessage;
    GameObject wallToMakeVanish;

    protected override void Start()
    {
        base.Start();
        text.text = DeathMessage + touchePourRespawnMsg;
    }

    protected override void Respawning()


    {
        base.Respawning();
        wallToMakeVanish.SetActive(false);
    }


}