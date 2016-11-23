using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable once CheckNamespace
public class PlayerController2D : PlayerControllerBase
{




    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene04":
                Speed = 30000;
                JumpHeight = 150000;
                dragAirborn = 2;
                dragOnGround = 5;
                break;

            default:
                throw new UnityException(GetType().Name + " doesnt know this scene, add player controller values in script");
        }
    }
    protected void Rotation()
    {
    }

    protected void Move()
    {

        float moveV = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        if (!IsGrounded)
            moveV *= 0.3f;

        if (Input.GetAxis("Vertical") > 0.9)
            moveV *= 1.5f;

        //Debug.Log("MoveH = " + moveH + " moveV = " + moveV);
        Rb.AddForce(transform.forward * moveV);


        Animator.SetBool(CharacterAnimatorState.isMoving.ToString(), ( /*Math.Abs(moveV) +*/ Math.Abs(moveV)) > 0);

        Animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);

        Animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
    }

    // ReSharper disable once UnusedMember.Local
    private void FixedUpdate()
    {
        Move();
        Jump();
        ChangeDrag();

    }




}