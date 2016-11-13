using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour 
{
	static SceneManagement instance = null;
	IndexLevel index;

	public bool openDoor = false;

	void Start()
	{

		index = FindObjectOfType<IndexLevel>();
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
			SceneManager.LoadScene ("Game Over");
			openDoor = true;
		}
	}

	void Update()
	{
		int levelActuel = 0;

		/*if(levelActuel != index && index != 5)
		{
			levelActuel = index;
		}*/
	}


}
