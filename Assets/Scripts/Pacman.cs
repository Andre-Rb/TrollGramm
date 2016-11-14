using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour 
{
<<<<<<< HEAD

	public float delaiPacman = 10.0f;
	bool wait = false;

=======
	public float attentePacman = 10.0f;
>>>>>>> 2c50243bbff60a78135a3e0b358dd74729330b35

	public Transform player;
	NavMeshAgent agent;

	void Start () 
	{
<<<<<<< HEAD

		agent = GetComponent<NavMeshAgent> ();

		StartCoroutine (Wait ());
=======
		StartCoroutine (Wait ());
	}

	IEnumerator Wait()
	{
		while(true)
		{
			yield return new WaitForSeconds (attentePacman);
			agent = GetComponent<NavMeshAgent> ();
		}
>>>>>>> 2c50243bbff60a78135a3e0b358dd74729330b35
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
