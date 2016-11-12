using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_Manette_Clavier : MonoBehaviour 
{
	public new GameObject camera = null;
	public float speed = 8.0f;
	public float speedrotate = 50.0f;
	public float height = 4.0f;

	private bool isGrounded = false;

	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		Move ();
		Rotation ();
		Jump ();
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

		transform.rotation *= Quaternion.Euler (0, rotV, 0);
		camera.transform.rotation *= Quaternion.Euler (rotH, 0, 0);
	}

	void Jump()
	{
		float jump = Input.GetAxis ("Jump") * height * Time.deltaTime;

		if(isGrounded)
		{
			rb.velocity = new Vector3 (0, jump, 0);
		}

	}

	void OnCollisionStay(Collision other)
	{
		isGrounded = true;
	}

	void OnCollisionExit(Collision other)
	{
		if (isGrounded) 
		{
			isGrounded = false;   
		}
	}

	/*void OnCollisionEnter(Collider other)
	{
		if(other.gameObject.tag == "Pacman")
		{
			Destroy (gameObject);
			SceneManager.LoadScene ("Game Over");
		}
	}*/
}
