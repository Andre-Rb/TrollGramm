using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	Switch bouton;

	void Start ()
	{
		bouton = GameObject.FindObjectOfType<Switch> ();
	}

	void Update () 
	{
		
		if(bouton.bouton == true)
		{
			gameObject.SetActive (false);
		}
	}
}
