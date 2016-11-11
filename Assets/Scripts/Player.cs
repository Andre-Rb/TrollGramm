using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 8.0f;
	public float height = 10.0f;
	public float speedRotate = 100.0f;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		Move ();
		Jump ();
		Rotataion ();
	}

	void Move()
	{
		float moveH = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float moveV = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		transform.Translate (new Vector3 (moveH, 0, moveV));
	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity = new Vector3 (0, height, 0);
		}
	}

	void Rotataion()
	{
		float rotateH = Input.GetAxis ("Xboxleft") * -speedRotate * Time.deltaTime;

		transform.Rotate (new Vector3 (0, rotateH, 0));
	}
}
