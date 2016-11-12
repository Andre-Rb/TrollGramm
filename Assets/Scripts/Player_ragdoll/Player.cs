using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8.0f;

    public float JumpHeight = 10.0f;
    public float rotationSpeed = 100.0f;
    Rigidbody rb;
    public bool Alive { get; set; }
    public bool isFPSMode;


    void Start()
    {
        Alive = true;

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Mouse();
        Jump();
    }

    void Move()
    {
        if (Alive)
        {

            float moveV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			float moveH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;


            float rotateH = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            //transform.Translate(new Vector3(0, 0, moveV));
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveV / 1.5f);
            //GetComponent<Rigidbody>().AddForce(transform.forward * moveV * 1000);
            transform.Rotate(new Vector3(0, rotateH, 0));


			transform.Translate(new Vector3(moveH, 0, moveV));
            //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveV);
           // GetComponent<Rigidbody>().AddForce(transform.forward * moveV);

        }
    }

    void Jump()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
				rb.velocity = new Vector3(0, JumpHeight, 0);
            }
        }
    }

    void Mouse()
    {
        if (Alive)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        }
    }
}
