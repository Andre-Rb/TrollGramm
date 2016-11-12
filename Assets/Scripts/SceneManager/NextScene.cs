using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour 
{
	void OnTriggerEnter()
	{
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
