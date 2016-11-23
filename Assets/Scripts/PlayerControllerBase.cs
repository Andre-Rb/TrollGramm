using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
public abstract class PlayerControllerBase : MonoBehaviour
{
    [SerializeField]
    protected float dragAirborn = 5;

    [SerializeField]
    protected float dragOnGround = 50;

    protected Camera PlayerCameraAutoSelected;
    [SerializeField]
    protected float Speed;
    protected Animator Animator;

    // ReSharper disable once InconsistentNaming
    protected bool playerIsDead;
    protected Rigidbody Rb;
    [SerializeField]
    protected float JumpHeight;

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

    protected Transform _nextRespawnTransform;

    public Transform NextRespawnTransform
    {
        get { return _nextRespawnTransform; }
        set { _nextRespawnTransform = value; }
    }
    protected DialogueTrigger _dialogueToPlayAfterRespawn;

    public DialogueTrigger DialogueToPlayAfterRespawn
    {
        get { return _dialogueToPlayAfterRespawn; }
        set { _dialogueToPlayAfterRespawn = value; }
    }
    protected void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

    }


    public void SetCamera(Camera c)
    {
        PlayerCameraAutoSelected = c;
    }

    public Camera GetCamera()
    {
        return PlayerCameraAutoSelected;
    }


    // ReSharper disable once UnusedMember.Local
    protected void Jump()
    {
        float jump = Input.GetAxis("Jump") * JumpHeight * Time.deltaTime;

        if (IsGrounded && Math.Abs(jump) > 0.01)
        {
            Rb.AddForce(transform.up * jump);

            Animator.SetTrigger(CharacterAnimatorState.ForwardJump.ToString());
            Debug.Log("has jumped");
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

    protected void ChangeDrag()
    {
        Rb.drag = IsGrounded ? dragOnGround : dragAirborn;
    }
}