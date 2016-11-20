using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

	void Update() {
		// Move the object to the right relative to the camera 1 unit/second.
		transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
	}
}
