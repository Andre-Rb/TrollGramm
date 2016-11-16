using System;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    public float Speed = 8.0f;
    public float RotationSpeed = 50.0f;

    public float JumpHeight = 4.0f;

    private bool isGrounded = false;

    private float forwardVelocity;

    private Animator _animator;



    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Rotation();
        Jump();
    }

    void Move()
    {
        float moveH = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        //float moveV = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        transform.Translate(new Vector3(0, 0, moveH));
        //rb.AddForce(transform.right * moveH * 4000);
        //rb.AddForce(transform.forward * moveV * 4000);

        _animator.SetBool(CharacterAnimatorState.isMoving.ToString(), (Math.Abs(0) + Math.Abs(moveH)) > 0);


        _animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);
        _animator.SetBool(CharacterAnimatorState.isStraffing.ToString(), Math.Abs(Input.GetAxis("Horizontal")) > 0);

        _animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
        _animator.SetFloat(CharacterAnimatorState.YWalking.ToString(), Input.GetAxis("Horizontal"));
    }

    void Rotation()
    {
        float rotH = Input.GetAxis("XboxleftX") * RotationSpeed * Time.deltaTime;
        float rotV = Input.GetAxis("XboxleftY") * RotationSpeed * Time.deltaTime;

        if (rotV != 0)
        {
            transform.rotation *= Quaternion.Euler(0, rotV, 0);
            _animator.SetBool(CharacterAnimatorState.isShuffling.ToString(), true);

        }
        else
        {
            _animator.SetBool(CharacterAnimatorState.isShuffling.ToString(), false);

        }
    }

    void Jump()
    {
        float jump = Input.GetAxis("Jump") * JumpHeight * Time.deltaTime;

        if (isGrounded)
        {

            rb.velocity = new Vector3(0, jump * 500, 0);

            _animator.SetTrigger(CharacterAnimatorState.ForwardJump.ToString());

        }

    }

    void OnCollisionStay(Collision other)
    {
        if (useGUILayout)
        {

            isGrounded = true;
            _animator.SetBool(CharacterAnimatorState.isGrounded.ToString(), true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (isGrounded)
        {
            isGrounded = false;
            _animator.SetBool(CharacterAnimatorState.isGrounded.ToString(), false);

        }
    }


    void CalcForwardVelocity()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        forwardVelocity = localVelocity.z;

        if (forwardVelocity > 0.1f)
            Debug.Log(forwardVelocity);
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