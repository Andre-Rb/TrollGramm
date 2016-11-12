using UnityEngine;
using System.Collections;

public class Switch2 : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Renderer rend = GetComponent<Renderer>();
			rend.material.shader = Shader.Find("Albedo");
			rend.material.SetColor("_SpecColor", Color.red);
		}
	}
}
