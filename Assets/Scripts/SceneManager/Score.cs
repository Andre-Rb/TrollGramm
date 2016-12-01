using UnityEngine;

public class Score : MonoBehaviour 
{
	public GameObject Exit = null;
	public int scoreMax;

    public FourteenDialogue Dialogue;

    private int score;


	void OnTriggerEnter(Collider other)
	{
		score++;
		Debug.Log (score);

		if(score == scoreMax)
		{
			gameObject.SetActive (false);
			Exit.SetActive (true);
            Dialogue.PlayDialogue();

        }
	}
}
