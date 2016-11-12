using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {
	
	void Start ()
	{
		
		//Causes UI object not to be destroyed when loading a new scene. If you want it to be destroyed, destroy it manually via script.
		DontDestroyOnLoad (this.gameObject);
		//newscene.buildIndex = SceneManager.GetActiveScene.buildIndex ();
		// (SceneManager.GetActiveScene.buildIndex () == oldScene.buildIndex) {
			

		//}

	

	}
}
