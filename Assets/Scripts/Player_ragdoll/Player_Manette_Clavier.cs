using UnityEngine;
using System.Collections;

public class Player_Manette_Clavier : MonoBehaviour 
{
	public float speed = 8.0f;
	public float speedrotate = 50.0f;

	void Update () 
	{
		Move ();
		Rotation ();
	}

	void Move()
	{
		float moveH = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float moveV = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		transform.Translate (new Vector3 (moveH, 0, moveV));
	}

	void Rotation()
	{
		float rotH = Input.GetAxis ("XboxleftX") * speedrotate * Time.deltaTime;
		float rotV = Input.GetAxis ("XboxleftY") * speedrotate * Time.deltaTime;

		transform.rotation *= Quaternion.Euler (rotH, 0, 0);
	}
}
