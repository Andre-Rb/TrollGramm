using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour 
{
	IndexLevel index;

	void Start()
	{
		index = FindObjectOfType<IndexLevel> ();
	}

	public void TryAgain()
	{
			SceneManager.LoadScene (index.index);
	}
}
