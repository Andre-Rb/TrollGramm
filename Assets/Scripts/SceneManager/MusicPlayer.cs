using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance;
	void Start () 
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
}
