using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour 
{
	public Transform player;
	NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () 
	{
		agent.SetDestination (player.position);
	}
}
