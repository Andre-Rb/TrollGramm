using UnityEngine;

public class SceneManagement : MonoBehaviour 
{
	static SceneManagement instance = null;

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
			DontDestroyOnLoad (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		openDoor = true;
	}
}
