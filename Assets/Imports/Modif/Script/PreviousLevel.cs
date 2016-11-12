using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreviousLevel : MonoBehaviour {
	public int oldIndex;
	public int nouvIndex;
	public bool isOld;


	// Use this for initialization
	void OnLevelWasLoaded() {
		
		//Debug.Log ("test1, previouslevel");
		nouvIndex = SceneManager.GetActiveScene().buildIndex;
		isOld = (oldIndex == nouvIndex);
		if (isOld) {
			oldIndex = nouvIndex;
			Debug.Log (nouvIndex + " " + oldIndex);


		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}




//newscene.buildIndex = SceneManager.GetActiveScene.buildIndex ();
// (SceneManager.GetActiveScene.buildIndex () == oldScene.buildIndex) {

//private string Scene.name (sc) = SceneManager.GetActiveScene ();
//}