using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoutonRetry : MonoBehaviour 
{
	public string scene = "";

	public void Retry()
	{
		SceneManager.LoadScene (scene);
	}
}
