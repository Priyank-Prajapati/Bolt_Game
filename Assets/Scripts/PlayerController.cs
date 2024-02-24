using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //private inspector variable
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private Transform groundCheckPos; //ground check overlapcircle position
    [SerializeField] private float groundCheckRadius; //ground check overlapcircle radius
    [SerializeField] private LayerMask whatIsGround; //ground Layer Mask
    public Text txt;
    public static bool isDead = false;
    public AudioSource audio;

    //private variable
    private Rigidbody2D rBody;
    private bool isRunning = false;
    private bool isGrounded = false;
    private Animator anim;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isRunning && Input.GetAxis("Jump") > 0)
        {
            isRunning = true;
        }
        if(isRunning)
        { 
            rBody.velocity = new Vector2(speed, rBody.velocity.y);
        }

        //check if on ground
        isGrounded = GroundCheck();
        //jump code
        if (isRunning && isGrounded && !isDead && Input.GetAxis("Jump") > 0 )
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            audio.Play();
        }

        if(isDead)
        {
            isRunning = false;
        }
        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDead", isDead);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            txt.enabled = true;
            isRunning = false;
        }
    }
}
