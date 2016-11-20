using System;
using UnityEngine;
using UnityEngine.UI;

public class Player_Manette_Clavier : MonoBehaviour
{
    public Camera PlayerCamera = null;
    public GameObject cameraGameOver = null;
    public Text GameOverText = null;
    public DialogueTrigger DialogueToPlayAfterRespawn = null;
    public float Speed = 8.0f;
    public float RotationSpeed = 50.0f;
    public Transform NextRespawnTransform;
    public float JumpHeight;
    public GameObject HeadGameObject;
    public bool showHead;

    private bool _isGrounded;

    private float forwardVelocity;

    private Animator _animator;
    private bool _playerIsDead;

    public bool PlayerIsDead
    {
        get { return _playerIsDead; }
        set { _playerIsDead = value; }
    }


    Rigidbody rb;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            _isGrounded = value;
            _animator.SetBool(CharacterAnimatorState.isGrounded.ToString(), value);
        }
    }


    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        JumpHeight = 300f;
    }


    void Move()
    {
        float moveH = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float moveV = Input.GetAxis("Vertical") * Speed * Time.deltaTime;


        if (moveH > 0)
            moveH *= 2;
        transform.Translate(new Vector3(moveH, 0, moveV));
        //rb.AddForce(transform.right * moveH * 4000);
        //rb.AddForce(transform.forward * moveV * 4000);

        _animator.SetBool(CharacterAnimatorState.isMoving.ToString(), (Math.Abs(moveV) + Math.Abs(moveH)) > 0);


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


        Quaternion nextRotation = PlayerCamera.transform.rotation * Quaternion.Euler(rotH, 0, 0);
        if (nextRotation.eulerAngles.x <= 80 || nextRotation.eulerAngles.x >= 280)
            PlayerCamera.transform.rotation = nextRotation;
    }

    void Jump()
    {
        float jump = Input.GetAxis("Jump") * JumpHeight * Time.deltaTime;

        if (IsGrounded && Math.Abs(jump) > 0.01)
        {
            rb.velocity = new Vector3(0, jump, 0);

            _animator.SetTrigger(CharacterAnimatorState.ForwardJump.ToString());
        }
    }

    // ReSharper disable once UnusedMember.Local
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == Tags.Ground.ToString())
            IsGrounded = true;
    }

    // ReSharper disable once UnusedMember.Local
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == Tags.Ground.ToString())
            IsGrounded = false;
    }


    void CalcForwardVelocity()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        forwardVelocity = localVelocity.z;

        if (forwardVelocity > 0.1f)
            Debug.Log(forwardVelocity);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsDead)
        {
            Respawning();
        }
    }


    void Respawning()
    {
        PlayerCamera.gameObject.SetActive(true);
        cameraGameOver.gameObject.SetActive(false);
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


    /*void OnCollisionEnter(Collider other)
                    {
                        if(other.gameObject.tag == "Pacman")
                        {
                            Destroy (gameObject);
                            SceneManager.LoadScene ("Game Over");
                        }
                    }*/
}