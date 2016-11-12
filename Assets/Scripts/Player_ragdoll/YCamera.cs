using UnityEngine;
using System.Collections;

public class YCamera : MonoBehaviour 
{
	public float speedRotate = 200.0f;

	void Update () 
	{
		Mouse ();
	}

	void Mouse()
	{
		float mouseY = -Input.GetAxis ("Mouse Y");
		transform.rotation *= Quaternion.Euler (mouseY, 0, 0);
	}
}
