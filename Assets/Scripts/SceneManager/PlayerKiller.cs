using UnityEngine;
using UnityEngine.UI;

public class PlayerKiller : MonoBehaviour
{
    public Player_Manette_Clavier player;
    public Transform ReswpanPoinTransform;

    public Camera cameraPlayer = null;
    public Camera cameraGameOver = null;
    public Text text;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraPlayer.gameObject.SetActive(false);
            cameraGameOver.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            player.PlayerIsDead = true;
        }
    }

    void Update()
    {
  
    }


    protected virtual void Respawning()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cameraPlayer.gameObject.SetActive(true);
        cameraGameOver.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}