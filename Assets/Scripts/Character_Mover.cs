using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Mover : MonoBehaviour
{
    private CharacterController playerController;
    private PlayerInput input;
    private float Hor;
    private float Ver;
    [SerializeField]
    private Vector2 inputVector;
    [SerializeField] float rotationSpeed;
    [SerializeField] float JumpHeight;
    [SerializeField] float gravityMultipliyer;

    float ySpeed;
    float oriStepOff;

    [SerializeField] float jumpGraceTime;
    float? lastGroundTime;  // ? the value is initially setted to null 
    float? jumpPressedTime;

    Animator animator;
    [SerializeField] Transform cameraTransform;
    private bool IsJumping;
    private bool IsGrounded;

    [SerializeField] float jumpHorizontalSpeed;


    private void Awake()
    {
        input = new();
        input.Player.Enable();
        input.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        
    }
    private void OnDisable()
    {
        input.Player.Jump.performed -= Jump_performed;
        input.Player.Disable();
    }
    void Start()
    {

       animator = GetComponent<Animator>();
       playerController= GetComponent<CharacterController>();
       oriStepOff = playerController.stepOffset;
       //Debug.Log("<color=red>I Am KD!</color>" + " And I Love Games");
    }
    void Update()
    {
        inputVector = input.Player.Movement.ReadValue<Vector2>();
        Vector3 movementDir = new Vector3(inputVector.x,0, inputVector.y);
        float inputMagnitude = Mathf.Clamp01(movementDir.magnitude);

        if(Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)||Input.GetButton("Fire3"))   // walk
        {
            inputMagnitude /= 2;
        }
        animator.SetFloat("InputMagnitude", inputMagnitude,0.05f,Time.deltaTime); // setting input magnitude

        movementDir = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDir;  // turning character as per camera facing towards
        movementDir.Normalize();

        float gravity = Physics.gravity.y * gravityMultipliyer;

        if(IsJumping&&ySpeed>0&&Input.GetButton("Jump")==false)  // HighJump if the key is held long
        {
            gravity *= 2;
        }
        ySpeed += gravity * Time.deltaTime;  

        if(playerController.isGrounded)
        {
            lastGroundTime = Time.time;
        }
        if(Input.GetButtonDown("Jump"))
        {
            jumpPressedTime = Time.time;
        }

        if (Time.time - lastGroundTime <= jumpGraceTime)
        {
            playerController.stepOffset = oriStepOff;
            ySpeed = -0.5f;

            animator.SetBool("IsGrounded", true);
            IsGrounded = true;

            animator.SetBool("IsJumping", false);
            IsJumping = false;

            animator.SetBool("IsFalling", false);

            if (Time.time - jumpPressedTime <= jumpGraceTime)      // for jumping for edges
            {
                ySpeed = Mathf.Sqrt(JumpHeight * -3 * gravity);
                animator.SetBool("IsJumping", true);
                IsJumping = true;
                jumpPressedTime = null;
                lastGroundTime = null;
            }
        }
        else
        {
            playerController.stepOffset = 0f;
            animator.SetBool("IsGrounded", false);
            IsGrounded = false;

            if((IsJumping && /*ySpeed > 5) ||*/ ySpeed < -2)) // if yspeed < 0 means it can play falling animations.
            {
                animator.SetBool("IsFalling", true);
            }
        }
        if (movementDir != Vector3.zero)           // rotating character
        {
            animator.SetBool("IsMoving", true);
            Quaternion t_rotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rotation, rotationSpeed * Time.deltaTime);
        }
        else animator.SetBool("IsMoving", false);

        if(!IsGrounded)                     // moving character while jumping 
        {
            Vector3 velocity = movementDir * inputMagnitude*jumpHorizontalSpeed;
            velocity.y = ySpeed;
            playerController.Move(velocity*Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Rasengan");
        }

    }
    private void OnAnimatorMove()
    {
        if(IsGrounded)                   // moving character while on ground
        {
            Vector3 velocity = animator.deltaPosition;   // moving by root motion
            velocity.y = ySpeed * Time.deltaTime;
            playerController.Move(velocity);
        } 
    }
    private void OnApplicationFocus(bool focus)  // locking cursor when button is pressed 
    {                                            // To make reappear the cursor press ESCAPE
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;   
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
