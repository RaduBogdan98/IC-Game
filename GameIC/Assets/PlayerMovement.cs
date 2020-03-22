using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float horizontalMovement;
    public float speed = 40;
    private bool jump = false;
    private bool crouch = false;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            animator.SetTrigger("IsHurt");
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
        animator.SetTrigger("hasLanded");
    }
}
