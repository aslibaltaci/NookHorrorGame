using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Moving Speed
    private float movSpeed;
    public float walkSpeed;
    public float RunSpeed;

    public Transform body;

    public float Dragging;
    public float playerHeight;

    //For Jumping 
    public float jumpPower;
    public float cooldown;
    public float airMovement;

    //For Crouching 
    public float crouchSpeed;
    public float crochScale;
    private float crouchStart;

    public LayerMask Ground;

    bool grounded;
    bool jumping;

    float horizontalInput;
    float verticalInput;

    public MovementState state;


    private AudioSource Sound;
    public AudioClip OutOfBreath;
    public AudioClip Walking;

    public enum MovementState
    {
        walk,
        run,
        air,
    }

    Vector3 movDir;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        crouchStart = transform.localScale.y;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;

        Sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.7f, Ground);

        MyInput();
        SpeedChecker();

        if (grounded)
        {
            rb.drag = Dragging;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerMovements();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

       // if (Input.GetButtonDown("Jump") && grounded)
       // {
          //  Jump();
            //jumping = false;

            //Invoke(nameof(ResetJumping), cooldown);
       // }

        if (Input.GetButtonDown("Crouch/Back"))
        {
            transform.localScale = new Vector3(transform.localScale.x, crochScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetButtonUp("Crouch/Back"))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchStart, transform.localScale.z);
        }

        if(Input.GetAxis("Sprint") < 0)
        {
            state = MovementState.run;
            movSpeed = RunSpeed;
            RunSpeed -= Time.deltaTime;
            if(RunSpeed == 7)
            {
                state = MovementState.walk;
                movSpeed = walkSpeed;
            }
            
            if(RunSpeed <= 6)
            {
                RunSpeed += 7;
            }
        }
        else
        {
            state = MovementState.walk;
            movSpeed = walkSpeed;
        }
    }

    private void PlayerMovements()
    {
        movDir = body.forward * verticalInput + body.right * horizontalInput;

        //rb.AddForce(movDir.normalized * movSpeed * 10f, ForceMode.Force);

        if (grounded)
        {
            rb.AddForce(movDir.normalized * movSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(movDir.normalized * movSpeed * 10f * airMovement, ForceMode.Force);
        }
    }

    void Jump()
    {
        Vector3 movement = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        rb.velocity = movement;
        // rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }

    void ResetJumping()
    {
        jumping = true;
    }

    private void SpeedChecker()
    {
        Vector3 VelocityCheck = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (VelocityCheck.magnitude > movSpeed)
        {
            Vector3 VelocityLimit = VelocityCheck.normalized * movSpeed;
            rb.velocity = new Vector3(VelocityLimit.x, rb.velocity.y, VelocityLimit.z);
        }
    }

}
