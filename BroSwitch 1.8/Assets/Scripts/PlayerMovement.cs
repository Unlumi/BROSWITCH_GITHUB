using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [HideInInspector] public bool isGrounded;

    public float Speed;

    [HideInInspector] public float jumpHeight;

    public GameObject GroundedTrigger;

    private Rigidbody2D rb;

    public AudioSource JumpSound;

    private void Start()
    {
        isGrounded = false;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInputs();

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(rb.velocity.x > 0.1f || rb.velocity.x < -0.1f)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);

            if(rb.velocity.x > 0.1f)
            {
                transform.localScale = new Vector2(-1.5f, transform.localScale.y);
            } else
            {
                transform.localScale = new Vector2(1.5f, transform.localScale.y);
            }

        } else
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
 
    {
        rb.velocity = new Vector2(horizontalInput * Speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    // FUNCTIONS_____________________________________________________________________________________________________________________________

    private void CheckInputs()
    {
        if (/*(Input.GetKeyDown(KeyCode.Space) || */(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        JumpSound.Play();
    }
}
