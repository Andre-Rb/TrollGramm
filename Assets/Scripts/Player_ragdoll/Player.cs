using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8.0f;
    public float height = 10.0f;
    public float speedRotate = 200.0f;
    Rigidbody rb;
    public bool Alive { get; set; }


    void Start()
    {
        Alive = true;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
		Mouse ();
        Jump();
    }

    void Move()
    {
        if (Alive)
        {

            float moveV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			float moveH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

			transform.Translate(new Vector3(moveH, 0, moveV));
        }
    }

    void Jump()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0, height, 0);
            }
        }
    }

	void Mouse()
	{
		if(Alive)
		{
			float mouseX = Input.GetAxis ("Mouse X") * speedRotate * Time.deltaTime;

			transform.rotation *= Quaternion.Euler (0, mouseX, 0);
		}
	}
}
