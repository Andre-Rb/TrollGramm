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
			transform.position = new Vector3 (transform.position.x, -0.033f, transform.position.z);
		}
	}
}
