using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour 
{
	TrueSwitch2 switch2 = null;

	void Start () 
	{
		switch2 = FindObjectOfType<TrueSwitch2> ();
	}

	void Update () 
	{
		if (switch2.exit == true) 
		{
			gameObject.SetActive (false);
		}
	}
}
