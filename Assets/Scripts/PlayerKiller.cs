using UnityEngine;
using UnityEngine.UI;

public class PlayerKiller : MonoBehaviour
{
    public PlayerControllerBase player;
    public Transform ReswpanPointTransform;

    public Camera cameraGameOver = null;
    public Text text;

	private int nbreAleatoire = 0;

    protected string touchePourRespawnMsg;


    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        if (player == null)
        {
            throw new UnityException("You have to provide a PlayerController to " + GetType().Name);
        }
    }
    protected virtual void SetMessage()
    {
        touchePourRespawnMsg = "\nAppuie sur " + "TODO" + " pour respawn.";
		text.text = MessageGameOver();
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
            player.GetCamera().gameObject.SetActive(false);
            cameraGameOver.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            player.PlayerIsDead = true;
            player.NextRespawnTransform = ReswpanPointTransform;

        }
    }


	string MessageGameOver()
	{
		string text = "";

		text = "Pasteque";

		return text;
	}

}