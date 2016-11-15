using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour 
{
	public Camera cameraPlayer = null;
	public Camera cameraGameOver = null;
	public Text text;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			cameraPlayer.gameObject.SetActive (false);
			cameraGameOver.gameObject.SetActive (true);
			text.gameObject.SetActive (true);
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			cameraPlayer.gameObject.SetActive (true);
			cameraGameOver.gameObject.SetActive (false);
			text.gameObject.SetActive (false);

		}
	}
}
