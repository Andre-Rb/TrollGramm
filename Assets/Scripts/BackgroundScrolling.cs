using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrolling = 0f;

	void Update ()
	{
		transform.position += new Vector3 (scrolling, 0, 0);
	}
}