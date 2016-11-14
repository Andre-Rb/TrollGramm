using UnityEngine;

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
<<<<<<< HEAD

			gameObject.SetActive (false);
			Exit.SetActive (true);

=======
			gameObject.SetActive (false);
			Exit.SetActive (true);
>>>>>>> 2c50243bbff60a78135a3e0b358dd74729330b35
		}
	}
}
