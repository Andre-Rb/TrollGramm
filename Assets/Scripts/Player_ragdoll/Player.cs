﻿using System;
using UnityEngine;


enum AnimationParams
{
    TrgIdle,
    Velocity,
    TrgWalking
}

public class Player : MonoBehaviour
{
    public float speed = 8.0f;

    public float JumpHeight = 10.0f;
    public float rotationSpeed = 100.0f;
    public bool Alive { get; set; }
    public bool isFPSMode;

    Animator animator;
    private Rigidbody rdb;
    public float maxVelocity;
    bool isIdle;


    void Awake()

    {
        Alive = true;
        animator = GetComponent<Animator>();


        rdb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        Move();
        Mouse();
        Jump();

        //if (Math.Abs(rdb.velocity.x) > 0.1)
        //Debug.Log(rdb.velocity.x);

    }

    void Move()
    {
        if (Alive)
        {
            //TODO Slower on backsteps

            //Moving on axis
            float axisV = Input.GetAxis("Vertical");

            if (rdb.velocity.sqrMagnitude <= maxVelocity)
            {
                float moveV = axisV * speed * Time.deltaTime;

                rdb.AddForce(transform.forward * moveV * 10000);
                GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveV / 1.5f);

            }


            if (Math.Abs(axisV) < 0.01f)
            {
                rdb.velocity = new Vector3(0, rdb.velocity.y, 0);

            }
            Vector3 localVelocity = transform.InverseTransformDirection(rdb.velocity);
            float forwardSpeed = localVelocity.z;
            if (Math.Abs(forwardSpeed) < 0.1f)
                rotationSpeed = 200;
            else
            {
                rotationSpeed = 50;
            }
            float rotateH = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.Rotate(new Vector3(0, rotateH, 0));





            animator.SetFloat(AnimationParams.Velocity.ToString(), forwardSpeed);


        }
    }

    void Jump()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rdb.velocity = new Vector3(0, JumpHeight, 0);
            }
        }
    }

    void Mouse()
    {
        if (Alive && isFPSMode)
        {
            float mouseX = -Input.GetAxis("Mouse X") * rotationSpeed;

            transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        }
    }
}
