using UnityEngine;

public class Billes : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pacman")
		{

		}
	}
}
