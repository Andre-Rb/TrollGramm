using UnityEngine;
using UnityEngine.SceneManagement;

public class CarKiller : MonoBehaviour
{

    public PlayerControllerBase PlayerControllerBase;

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collsion ! ");

        if (collision.gameObject.CompareTag(Tags.Player.ToString()))
        {
            PlayerControllerBase.GetComponent<RagdollSwitch>().Kill();

            Invoke("Reload", 5f);
            PlayerControllerBase.GetComponent<Collider>().enabled = false;
        }
    }


    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
