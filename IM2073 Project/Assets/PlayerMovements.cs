using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //VARIABLES
    public float movespeed;
    public float walkspeed;
    public float runspeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    public bool isGrounded;
    public float groundCheckDistance;
    public LayerMask groundMask;
    public float gravity;

    public float jumpHeight;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public bool isWalking = false;
    public FootStepGenerator stepGenerator;
    public float footStepTimer;

    //REFERENCES
    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        stepGenerator = GetComponent<FootStepGenerator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        
        if(isGrounded)
        {
            if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero){
                Idle();
            }

            moveDirection *= movespeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        movespeed = walkspeed;
        anim.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        movespeed = runspeed;
        anim.SetFloat("Speed", 1);

        if(!isWalking)
        {
            PlayFootSound();
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetFloat("Speed", 0);
    }

    void PlayFootSound()
    {
        StartCoroutine("PlayStepSound", footStepTimer);
    }

    IEnumerator PlayStepSound(float timer)
    {
        var randomIndex = Random.Range(0,2);
        stepGenerator.footStepSource.clip = stepGenerator.footStepSounds[randomIndex];

        stepGenerator.footStepSource.Play();
        isWalking = true;

        yield return new WaitForSeconds(timer);
        isWalking = false;
    }
}
