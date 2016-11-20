using UnityEngine;
using System.Collections;

public class FirstSwitch : Switch {
    public SecondDoor Door;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Player.ToString())
        {
            Door.OpenDoor();
        }
    }
}
