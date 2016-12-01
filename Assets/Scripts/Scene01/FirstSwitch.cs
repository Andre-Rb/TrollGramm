using UnityEngine;
using System.Collections;

public class FirstSwitch : Switch {
    public SecondDoor Door;
	private bool action = false;

	void Update()
	{
		action = Input.GetButtonDown ("BlueFilter");
	}

    void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == Tags.Player.ToString() && action)
        {
            Door.OpenDoor();
        }
    }
}
