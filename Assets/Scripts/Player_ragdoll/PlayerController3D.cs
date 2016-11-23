using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class PlayerController3D : PlayerControllerBase
{
 

    public GameObject CameraGameOver;
    public Text GameOverText;
    public float RotationSpeed = 50.0f;
 

    //private float forwardVelocity;

    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        NextRespawnTransform = null;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene01":
                Speed = 20000;
                RotationSpeed = 200;
                JumpHeight = 150000;
                break;

            case "Scene02":
                Speed = 60000;
                RotationSpeed = 300;
                JumpHeight = 150000;
                break;

            case "Scene03":
                Speed = 30000;
                RotationSpeed = 200;
                JumpHeight = 250000;
                break;
            case "Scene05":
                Speed = 20000;
                RotationSpeed = 200;
                JumpHeight = 150000;
                break;

            default:
                throw new UnityException(GetType().Name + " doesnt know this scene, add player controller values in script");
        }
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

        //Debug.Log("MoveH = " + moveH + " moveV = " + moveV);
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
        if (!playerIsDead)
        {
            Move();
            Rotation();
            ChangeDrag();
            Jump();

        }

    }

   
}