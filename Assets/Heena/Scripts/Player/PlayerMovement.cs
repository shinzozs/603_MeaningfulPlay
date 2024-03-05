using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [HideInInspector] public float originalmoveSpeed;
    public float moveSpeed;
    public float sprintspeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    private KeyCode sprintkey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    public bool isGrounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Rigidbody rb;
    Vector3 moveDirection;

    private bool isRunning = false;
    private bool isRegen = false;
    [HideInInspector] public StaminaController StaminaController;

    private Animator animator;

    private void Start()
    {
        StaminaController = GetComponent<StaminaController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        originalmoveSpeed = moveSpeed;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 5;
        }
        MyInput();
        SpeedControl();
        Sprint();

        if (isRunning && (moveDirection.x != 0 || moveDirection.y != 0 || moveDirection.z != 0) && !isRegen)
        {
            moveSpeed = sprintspeed;
            StaminaController.playerStamina -= StaminaController.staminaDrain * Time.deltaTime;
            StaminaController.sliderCanvassGroup.alpha = 1;
            Debug.Log("Sprinting");

            if (StaminaController.playerStamina <= 0)
            {
                StaminaController.playerStamina = 0;
                moveSpeed = originalmoveSpeed;
                isRegen = true;
            }
            StaminaController.staminaProgressUI.fillAmount = StaminaController.playerStamina / StaminaController.maxStamina;
        }
        else
        {
            moveSpeed = originalmoveSpeed;
            if (!isRunning && isRegen || !isRegen)
            {
                StaminaController.playerStamina += StaminaController.staminaRegen * Time.deltaTime;
                Debug.Log("Regening");

                if (StaminaController.playerStamina >= 100)
                {
                    StaminaController.playerStamina = 100;
                    StaminaController.sliderCanvassGroup.alpha = 0;
                    isRegen = false;
                }
                else
                {
                    //isRegen = true;
                }
                StaminaController.staminaProgressUI.fillAmount = StaminaController.playerStamina / StaminaController.maxStamina;
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(isGrounded && Input.GetKeyDown(jumpKey) && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Sprint()
    {
        if (Input.GetKey(sprintkey))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void Regen()
    {
        if (StaminaController.playerStamina <= 0)
        {
            isRegen = true;
        }
        else if (StaminaController.playerStamina >= 100)
        {
            isRegen = false;
        }
        else 
        { 
            isRegen = false; 
        }
    }
}
