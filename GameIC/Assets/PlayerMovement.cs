using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D rigidbody;
    private float horizontalMovement;
    public float speed = 40;
    private bool jump = false;
    private bool crouch = false;
    private bool isGrounded = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * 40;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("hasTakenOff");
            animator.SetBool("Jump", true);
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coins"))
        {
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Monster1"))
        {
            animator.SetTrigger("IsHurt");
            float position = collider.gameObject.transform.position.x - transform.position.x;
            if (position > 0)
            {
                rigidbody.velocity = new Vector2(-50, rigidbody.velocity.y + 5);
            }
            else
            {
                rigidbody.velocity = new Vector2(50, rigidbody.velocity.y + 5);
            }
        }
        else if (collider.gameObject.CompareTag("Monster2"))
        {
            animator.SetTrigger("IsHurt");
            float position = collider.gameObject.transform.position.x - transform.position.x;
            if (position > 0)
            {
                rigidbody.velocity = new Vector2(-20, rigidbody.velocity.y + 20);
            }
            else
            {
                rigidbody.velocity = new Vector2(20, rigidbody.velocity.y + 20);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster1"))
        {
            float position = collision.gameObject.transform.position.x - transform.position.x;
            if (position > 0)
            {
                rigidbody.velocity = new Vector2(15, rigidbody.velocity.y + 15);
            }
            else
            {
                rigidbody.velocity = new Vector2(-15, rigidbody.velocity.y + 15);
            }
        }
        else if (collision.gameObject.CompareTag("Monster2"))
        {
            float position = collision.gameObject.transform.position.x - transform.position.x;
            if (position > 0)
            {
                rigidbody.velocity = new Vector2(15, rigidbody.velocity.y + 15);
            }
            else
            {
                rigidbody.velocity = new Vector2(-15, rigidbody.velocity.y + 15);
            }
        }
        else if (collision.gameObject.CompareTag("Dart"))
        {
            animator.SetTrigger("IsHurt");
            rigidbody.velocity = new Vector2(30, rigidbody.velocity.y + 5);
        }

    }

    //Move character
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        isGrounded = !isGrounded;

        Debug.Log("is grounded");

        animator.SetTrigger("hasLanded");
    }
}
