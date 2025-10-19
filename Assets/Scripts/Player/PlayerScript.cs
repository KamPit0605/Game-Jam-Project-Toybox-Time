using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerClass PlayerClass;
    public InputActionReference inputJump;
    public InputActionReference inputPause;

    public GameObject ForceField;
    public float speed;
    public float jumpHeight;
    public float gravity;
    /*
    [SerializeFeild] private float speed;
    [SerializeField] private float jumpheight = 2f;
    [SerializeField] private float gravity = 8f;
    */

    public float SpeedPowerUpTimer = 0f;
    public float SpeedMultiplier = 5f;
    public float invulnerableTimer = 0f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 velocity;

    public bool jumpPressed;
    public float jumpHeld;
    private float jumpHeldMax;

    public bool pausePressed;
    //private bool onFloor;

    // Start is called before the first frame update
    void Start()
    {

        inputJump.action.canceled += Jump_released;
        //inputPause.action.performed += OnPause;
        //controller = GetComponent<CharacterController>();
        speed = PlayerClass.playerSpeed;
        jumpHeight = PlayerClass.playerJumpHeight;
        gravity = PlayerClass.gravity;
        jumpHeldMax = PlayerClass.jumpHeldMax;

        //ForceField = GetComponent<GameObject>();
        ForceField.SetActive(false);
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        
    }

    private void OnEnable()
    {
        inputPause.action.performed += OnPause;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"Move Input: {moveInput}");

    }

    //Jumping Functions
    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log($"Jumping {context.performed} - Is Grounded:")
        jumpPressed = true;

        
        if (jumpPressed == true && IsGrounded)
        {
            velocity.y = -(jumpHeight) * gravity;
           
        }
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        pausePressed = true;
    }

    private void Jump_released(InputAction.CallbackContext obj)
    {
        jumpHeld = jumpHeldMax;
        gravity = gravity * 1.5f;
        //Debug.Log("Jump Released");

    }

    void Jumping()
    {
        if (jumpPressed == true) { jumpHeld = jumpHeld + 0.5f; }
        if (jumpHeld >= jumpHeldMax) {jumpPressed = false; }
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * SpeedMultiplier * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (SpeedPowerUpTimer > 0)
        {
            SpeedPowerUpTimer -= Time.deltaTime;
            SpeedMultiplier = 2f;  
        }
        else { SpeedMultiplier = 1f; }

        if (invulnerableTimer > 0)
        {
            invulnerableTimer -= Time.deltaTime;
            speed = PlayerClass.playerSpeed;
            jumpHeight = PlayerClass.playerJumpHeight;
            ForceField.SetActive(true);
        }
        else { ForceField.SetActive(false); }

        Jumping();
        Grounding();
        PlayerAdjustment();
    }

    private bool IsGrounded => controller.isGrounded;


    //Grounding function (on ground)
    void Grounding()
    {
        if (IsGrounded)
        {
            gravity = PlayerClass.gravity;
            jumpPressed = false;
            jumpHeld = 0f;
        }
        else
        {
            if (jumpHeld >= jumpHeldMax)
            {
                velocity.y += jumpHeight * gravity * Time.deltaTime;
                //velocity.y += gravity * Time.deltaTime;
            }

        }
    }

    void PlayerAdjustment()
    {
        if (speed <= 0f)
        {
            speed = 2f;
        }
    }


    //Interaction Functions

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Speed"))
        {
            SpeedPowerUpTimer = 1.75f;
        }
        if (collision.CompareTag("Shield"))
        {
            invulnerableTimer = 5f;
        }

        /*
        if (collision.CompareTag("Slow Field"))
        {
            speed = 4f;
        }
        */
        if (collision.CompareTag("Tar"))
        {
            speed = speed - 2f;
            jumpHeight = 0.5f;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Slow Field"))
        {
            speed = 4f;
        }

    }

    private void OnTriggerExit(Collider collision) 
    {
        speed = PlayerClass.playerSpeed;
        jumpHeight = PlayerClass.playerJumpHeight;

        if (collision.CompareTag("Tar"))
        {
            jumpHeight = PlayerClass.playerJumpHeight;
        }
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        jumpPressed = false;
        jumpHeld = 0f;
        onFloor = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {
        onFloor = false;
        velocity.y = jumpHeight * gravity;
    }
    */
}
