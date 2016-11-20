using UnityEngine;
using UnityEngine.UI;

public class PlayerKiller : MonoBehaviour
{
    public Player_Manette_Clavier player;
    public Transform ReswpanPointTransform;

    public Camera cameraGameOver = null;
    public Text text;

    protected string touchePourRespawnMsg;



    protected virtual void SetMessage()
    {
        touchePourRespawnMsg = "\nAppuie sur " + "TODO" + " pour respawn.";
        text.text = "'Message de mort générique avec accent moqueur'";
        text.text += touchePourRespawnMsg;

    }


    // ReSharper disable once UnusedMember.Local
    protected virtual void OnCollisionEnter(Collision other)
    {
        SetMessage();

        Debug.Log("OnCollisionEnter " + gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("A player just collided with : " + gameObject.name);
            player.PlayerCamera.gameObject.SetActive(false);
            cameraGameOver.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            player.PlayerIsDead = true;
            player.NextRespawnTransform = ReswpanPointTransform;

        }
    }



  
}