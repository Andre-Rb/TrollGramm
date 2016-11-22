using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class PlayerController2D : PlayerControllerBase
{
    protected void Rotation()
    {
    }

    protected void Move()
    {
        float moveH = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        Debug.Log("moveH : " + moveH);

        Animator.SetBool(CharacterAnimatorState.isMoving.ToString(), ( /*Math.Abs(moveV) +*/ Math.Abs(moveH)) > 0);

        Animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);
        Animator.SetBool(CharacterAnimatorState.isStraffing.ToString(), Math.Abs(Input.GetAxis("Horizontal")) > 0);

        Animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
        Animator.SetFloat(CharacterAnimatorState.YWalking.ToString(), Input.GetAxis("Horizontal"));
    }

    // ReSharper disable once UnusedMember.Local
    private void FixedUpdate()
    {
        Move();
        Jump();
    }




}