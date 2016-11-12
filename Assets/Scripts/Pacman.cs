using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour 
{
	public float attentePacman = 10.0f;

	public Transform player;
	NavMeshAgent agent;

	void Start () 
	{
		StartCoroutine (Wait ());
	}

	IEnumerator Wait()
	{
		while(true)
		{
			yield return new WaitForSeconds (attentePacman);
			agent = GetComponent<NavMeshAgent> ();
		}
	}

	void Update () 
	{
		agent.SetDestination (player.position);
	}
}
