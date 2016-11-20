using System;
using UnityEngine;

public class Character2D : Player_Manette_Clavier
{
    protected new  void Rotation()
    {
      



    }

    protected new void Move()
    {

        //TODO
        //float moveH = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float moveH = Input.GetAxis("Vertical") * Speed * Time.deltaTime;


        if (moveH > 0)
            moveH *= 2;
        //transform.Translate(new Vector3(moveH, 0, moveV));


        _animator.SetBool(CharacterAnimatorState.isMoving.ToString(), (/*Math.Abs(moveV) +*/ Math.Abs(moveH)) > 0);


        _animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);
        _animator.SetBool(CharacterAnimatorState.isStraffing.ToString(), Math.Abs(Input.GetAxis("Horizontal")) > 0);

        _animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
        _animator.SetFloat(CharacterAnimatorState.YWalking.ToString(), Input.GetAxis("Horizontal"));
    }
}