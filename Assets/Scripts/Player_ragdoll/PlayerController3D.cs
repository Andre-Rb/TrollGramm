using System;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class PlayerController3D : PlayerControllerBase
{
    [SerializeField]
    float dragAirborn = 5;

    [SerializeField]
    float dragOnGround = 50;

    public GameObject CameraGameOver;
    public Text GameOverText;
    DialogueTrigger _dialogueToPlayAfterRespawn;
    public float RotationSpeed = 50.0f;
    Transform _nextRespawnTransform;

    public Transform NextRespawnTransform
    {
        get { return _nextRespawnTransform; }
        set { _nextRespawnTransform = value; }
    }

    public DialogueTrigger DialogueToPlayAfterRespawn
    {
        get { return _dialogueToPlayAfterRespawn; }
        set { _dialogueToPlayAfterRespawn = value; }
    }

    //private float forwardVelocity;

    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        NextRespawnTransform = null;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsDead)
        {
            Respawning();
        }
    }


    // ReSharper disable once UnusedMember.Local
    void Move()
    {

        float moveH = 0;
        if (IsGrounded)
        {
            moveH = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        }
        float moveV = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        if (!IsGrounded)
            moveV *= 0.3f;

        if (Input.GetAxis("Vertical") > 0.9)
            moveV *= 1.5f;

        Debug.Log("MoveH = " + moveH + " moveV = " + moveV);
        Rb.AddForce(transform.right * moveH);
        Rb.AddForce(transform.forward * moveV);


        Animator.SetBool(CharacterAnimatorState.isMoving.ToString(), Math.Abs(moveV) + Math.Abs(moveH) > 0);

        Animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);
        Animator.SetBool(CharacterAnimatorState.isStraffing.ToString(), Math.Abs(Input.GetAxis("Horizontal")) > 0);

        Animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
        Animator.SetFloat(CharacterAnimatorState.YWalking.ToString(), Input.GetAxis("Horizontal"));
    }

    void Rotation()
    {
        float rotH = Input.GetAxis("XboxleftX") * RotationSpeed * Time.deltaTime;
        float rotV = Input.GetAxis("XboxleftY") * RotationSpeed * Time.deltaTime;

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (rotV != 0)
        {
            transform.rotation *= Quaternion.Euler(0, rotV, 0);
            Animator.SetBool(CharacterAnimatorState.isShuffling.ToString(), true);
        }
        else
        {
            Animator.SetBool(CharacterAnimatorState.isShuffling.ToString(), false);
        }


        Quaternion nextRotation = PlayerCameraAutoSelected.transform.rotation * Quaternion.Euler(rotH, 0, 0);
        if (nextRotation.eulerAngles.x <= 80 || nextRotation.eulerAngles.x >= 280)
            PlayerCameraAutoSelected.transform.rotation = nextRotation;
    }


    //void CalcForwardVelocity()
    //{
    //    Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    //    forwardVelocity = localVelocity.z;

    //    if (forwardVelocity > 0.1f)
    //        Debug.Log(forwardVelocity);
    //}


    void Respawning()
    {
        PlayerCameraAutoSelected.gameObject.SetActive(true);
        CameraGameOver.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        transform.position = NextRespawnTransform.position;
        PlayerIsDead = false;
        if (DialogueToPlayAfterRespawn != null)
        {
            DialogueToPlayAfterRespawn.PlayDialogue();
            DialogueToPlayAfterRespawn = null;
        }
    }

    public void FixedUpdate()
    {
        //CalcForwardVelocity();
        Move();
        Rotation();
        Jump();

        ChangeDrag();
    }

    private void ChangeDrag()
    {
        Rb.drag = IsGrounded ? dragOnGround : dragAirborn;
    }
}