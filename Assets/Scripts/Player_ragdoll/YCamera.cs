using UnityEngine;
using System.Collections;

public class YCamera : MonoBehaviour 
{
	public float speedRotate = 200.0f;
	public float max;
	public float min;

	void Update () 
	{
		Mouse ();
	}

	void Mouse()
	{
		float mouseY = -Input.GetAxis ("Mouse Y");
		transform.rotation *= Quaternion.Euler (mouseY*speedRotate, 0,	0);
	}
}
