using System;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class PlayerController3D : PlayerControllerBase
{
    public GameObject CameraGameOver = null;
    public Text GameOverText = null;
    public DialogueTrigger DialogueToPlayAfterRespawn;
    public float RotationSpeed = 50.0f;
    public Transform NextRespawnTransform;
    //private float forwardVelocity;


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
        float moveH = Input.GetAxis("Horizontal")*Speed*Time.deltaTime;
        float moveV = Input.GetAxis("Vertical")*Speed*Time.deltaTime;


        if (moveH > 0)
            moveH *= 2;
        transform.Translate(new Vector3(moveH, 0, moveV));


        Animator.SetBool(CharacterAnimatorState.isMoving.ToString(), (Math.Abs(moveV) + Math.Abs(moveH)) > 0);


        Animator.SetBool(CharacterAnimatorState.isWalkingStraight.ToString(), Input.GetAxis("Vertical") > 0);
        Animator.SetBool(CharacterAnimatorState.isStraffing.ToString(), Math.Abs(Input.GetAxis("Horizontal")) > 0);

        Animator.SetFloat(CharacterAnimatorState.XWalking.ToString(), Input.GetAxis("Vertical"));
        Animator.SetFloat(CharacterAnimatorState.YWalking.ToString(), Input.GetAxis("Horizontal"));
    }

    void Rotation()
    {
        float rotH = Input.GetAxis("XboxleftX")*RotationSpeed*Time.deltaTime;
        float rotV = Input.GetAxis("XboxleftY")*RotationSpeed*Time.deltaTime;

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


        Quaternion nextRotation = PlayerCameraAutoSelected.transform.rotation*Quaternion.Euler(rotH, 0, 0);
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
    }
}