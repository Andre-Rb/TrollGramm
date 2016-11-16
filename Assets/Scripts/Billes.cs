using UnityEngine;

public class Billes : MonoBehaviour 
{
	public AudioSource blop = null;

	void Start()
	{
		blop = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pacman")
		{
			blop.Play();
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<SphereCollider> ().enabled = false;
			gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
		}
	}
}
