using UnityEngine;
using System.Collections;

public class Billes : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pacman")
		{

		}
	}
}
