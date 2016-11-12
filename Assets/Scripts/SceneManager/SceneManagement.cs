using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour 
{
	static SceneManagement instance = null;

	public string scene = "";
	public bool openDoor = false;

	void Start()
	{
		if(instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			SceneManager.LoadScene (scene);
			openDoor = true;
		}
	}
}
