using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    internal static bool onFirstRun = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (!File.Exists(Application.persistentDataPath + "/fox.ini") || SceneManager.GetActiveScene().buildIndex == 1)
        {
            onFirstRun = true;
            File.Create(Application.persistentDataPath + "/fox.ini");

            HintRenderer.Instance.RenderHint("Welcome! I am Foxyu, and this is my Adventure!");
            HintRenderer.Instance.RenderHint("For me to move pres the left and right arrow keys!");
            HintRenderer.Instance.RenderHint("Press SPACE or up to make me jump!");
            HintRenderer.Instance.RenderHint("The camera will keep turning. That will annoy you quite a bit for sure!");
            HintRenderer.Instance.RenderHint("That's it for starters! Enjoy your ride!!");
        }
        else
        {
            onFirstRun = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * 40;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetButtonDown("Jump"))
        {
            SoundManagerScript.PlaySound("Jump");
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
            SoundManagerScript.PlaySound("sfx_sounds_impact5");
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
            SoundManagerScript.PlaySound("sfx_sounds_impact5");
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
            SoundManagerScript.PlaySound("sfx_sounds_impact5");
            animator.SetTrigger("IsHurt");
            rigidbody.velocity = new Vector2(30, rigidbody.velocity.y + 5);
            //HeartScore.health -= 1;
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            SoundManagerScript.PlaySound("sfx_sounds_impact5");
            animator.SetTrigger("IsHurt");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + 5, 15);
            //LivesScore.instance.ChangeScore(-1);
            HeartScore.health -= 1;
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
