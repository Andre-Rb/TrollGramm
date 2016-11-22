using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
public abstract class  PlayerControllerBase : MonoBehaviour
{

    protected Camera PlayerCamera;
    public float Speed = 8.0f;
    protected Animator Animator;

    // ReSharper disable once InconsistentNaming
    protected bool playerIsDead;
    protected Rigidbody Rb;
    public float JumpHeight;
    private bool _isGrounded;

    protected bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            _isGrounded = value;
            Animator.SetBool(CharacterAnimatorState.isGrounded.ToString(), value);
        }
    }

    public bool PlayerIsDead
    {
        get { return playerIsDead; }
        set { playerIsDead = value; }
    }


    protected void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

        JumpHeight = 300f;
    }



    public void SetCamera(Camera c)
    {
        PlayerCamera = c;
    }

    public Camera GetCamera()
    {
        return PlayerCamera;
    }


    // ReSharper disable once UnusedMember.Local
    protected void Jump()
    {
        float jump = Input.GetAxis("Jump") * JumpHeight * Time.deltaTime;

        if (IsGrounded && Math.Abs(jump) > 0.01)
        {
            Rb.velocity = new Vector3(0, jump, 0);

            Animator.SetTrigger(CharacterAnimatorState.ForwardJump.ToString());
        }
    }


    // ReSharper disable once UnusedMember.Local
    protected void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == Tags.Ground.ToString())
            IsGrounded = true;
    }

    // ReSharper disable once UnusedMember.Local
    protected void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == Tags.Ground.ToString())
            IsGrounded = false;
    }

}
