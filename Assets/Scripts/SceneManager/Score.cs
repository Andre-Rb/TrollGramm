using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public GameObject Exit = null;
	public int scoreMax = 50;

	int score = 0;

	void OnTriggerEnter(Collider other)
	{
		score++;
		Debug.Log (score);

		if(score == scoreMax)
		{
			gameObject.SetActive (false);
			Exit.SetActive (true);
		}
	}
}
