using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour 
{

	public string scene= "";

	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene (scene);
	}
}
