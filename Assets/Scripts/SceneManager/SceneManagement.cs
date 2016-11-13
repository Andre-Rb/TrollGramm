using UnityEngine;
using UnityEngine.SceneManagement;

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
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
