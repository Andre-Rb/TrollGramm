using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IndexLevel : MonoBehaviour 
{
	[HideInInspector] public int index = 0;

	void Update () 
	{
		if(index != 5)
		{
			index = SceneManager.GetActiveScene ().buildIndex;
		}
	}
}