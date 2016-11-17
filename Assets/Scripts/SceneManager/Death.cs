using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour 
{

    public Transform PlayerTransform;

	public Camera cameraPlayer = null;
	public Camera cameraGameOver = null;
	public Text text;
    public bool PlayerIsDead { get; set; }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			cameraPlayer.gameObject.SetActive (false);
			cameraGameOver.gameObject.SetActive (true);
			text.gameObject.SetActive (true);
		    PlayerIsDead = true;


        }
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && PlayerIsDead)
		{
			

		}
	}




    void Respawning()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cameraPlayer.gameObject.SetActive(true);
        cameraGameOver.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

    }

}
