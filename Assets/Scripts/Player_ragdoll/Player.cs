using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8.0f;
    public float height = 10.0f;
    public float speedRotate = 100.0f;
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
        Jump();
    }

    void Move()
    {
        if (Alive)
        {

            float moveV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float rotateH = Input.GetAxis("Horizontal") * speedRotate * Time.deltaTime;

            transform.Translate(new Vector3(0, 0, moveV));

            transform.Rotate(new Vector3(0, rotateH, 0));
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


}
