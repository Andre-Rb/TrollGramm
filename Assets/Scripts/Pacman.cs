using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour 
{

	public float delaiPacman = 10.0f;
	bool wait = false;


	public Transform player;
	NavMeshAgent agent;

	void Start () 
	{

		agent = GetComponent<NavMeshAgent> ();

		StartCoroutine (Wait ());
	}

	void Update()
	{
		if (wait) 
		{
			agent.SetDestination (player.position);

		}
	}

	IEnumerator Wait()
	{
		while(true)
		{
			yield return new WaitForSeconds(delaiPacman);

			wait = true;
		}
	}
}
