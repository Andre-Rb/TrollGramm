using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public GameObject door = null;
	public int scoreMax = 50;

	int score = 0;

	void OnTriggerEnter(Collider other)
	{
		score++;
		Debug.Log (score);

		if(score == scoreMax)
		{
			door.gameObject.SetActive (true);
			Destroy (gameObject);
		}
	}
}
