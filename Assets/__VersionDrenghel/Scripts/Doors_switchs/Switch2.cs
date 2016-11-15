using UnityEngine;

public class Switch2 : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Renderer rend = GetComponent<Renderer>();
			rend.material.color = Color.green;

			transform.position = new Vector3 (transform.position.x, -14.017f, transform.position.z);
		}
	}
}
