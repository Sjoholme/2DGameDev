using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadderScript : MonoBehaviour
{

    private float vertical;
    private float speed = 6;
    private bool isLadder;
    private bool isClimbing;
    private Animator anim;

    private Rigidbody2D rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        vertical = Input.GetAxis("vertical");

        Debug.Log(vertical);

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            Debug.Log("QAHWDFJOIAEJKMF");
            //isClimbing = true; 
            anim.SetBool("isClimbing", true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;

            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder= false;
            isClimbing= false;
        }
    }
}
