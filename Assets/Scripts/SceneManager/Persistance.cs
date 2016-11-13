using UnityEngine;
using System.Collections;

public class Persistance : MonoBehaviour
{
	static Persistance instance;
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
