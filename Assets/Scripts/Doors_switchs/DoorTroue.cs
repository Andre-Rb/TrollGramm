using UnityEngine;

public class DoorTroue : MonoBehaviour 
{
	SceneManagement door;

	void Start ()
	{
		door = GameObject.FindObjectOfType<SceneManagement> ();
	}

	void Update () 
	{
		if (door.openDoor == true) 
		{
			gameObject.SetActive (false);
		}
	}
}
