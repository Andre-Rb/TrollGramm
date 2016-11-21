using UnityEngine;
using System.Collections;

public class background : MonoBehaviour 
{
	public float scrolling = 0f;

	void Update() 
	{
		this.transform.GetComponent<Rigidbody2D>().velocity	= new Vector2 (scrolling, 0); 
	}
}
