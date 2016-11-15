using UnityEngine;

public class TrueSwitch2 : MonoBehaviour 
{
	public bool exit = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			exit = true;
		}
	}
}
