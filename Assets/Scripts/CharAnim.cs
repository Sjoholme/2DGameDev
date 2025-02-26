using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            FLip();
        } else if(facingRight == true && moveInput < 0)
        {
            FLip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else {
            anim.SetBool("isRunning", true); 
              }

	}

    void Update()
    {

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            
            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }

        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
    }

    void FLip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
