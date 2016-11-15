using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Arreter_le_filtre : MonoBehaviour 
{
	FilterSwitcher filtre;

	void start()
	{
		filtre = FindObjectOfType<FilterSwitcher> ();
	}

	void OnTriggerEnter(Collider other)
	{
		filtre.NormalView();

		SceneManager.LoadScene ("Scene04");
	}
}
