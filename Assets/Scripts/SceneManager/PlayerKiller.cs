using UnityEngine;
using UnityEngine.UI;

public class PlayerKiller : MonoBehaviour
{
    public Player_Manette_Clavier player;
    public Transform ReswpanPointTransform;

    public Camera cameraGameOver = null;
    public Text text;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.camera.gameObject.SetActive(false);
            cameraGameOver.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            player.PlayerIsDead = true;
        }
    }


    void Update()
    {
        if (player.PlayerIsDead && player.WantsToRespawn)
            Respawning();

    }

    protected virtual void Respawning()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.camera.gameObject.SetActive(true);
        cameraGameOver.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        player.transform.position = ReswpanPointTransform.position;
        player.WantsToRespawn = false;
    }
}