using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	public bool bouton = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			bouton = true;
		}
	}
}
