using UnityEngine;
using System.Collections;

public class TopCamera : MonoBehaviour 
{
	public Transform target;

	void Update () 
	{
		transform.LookAt(target);
	}
}
