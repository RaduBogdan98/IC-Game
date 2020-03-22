using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Transform player;
    public Collider2D fistCollider;
    public Collider2D hurtCollider;
    private float horizontalMovement;
    private int frames;
    private int direction = -1;
    private bool isAttacking = false;
    private float activationTime;

    private void Start()
    {
        frames = 0;
        activationTime = -1;
    }

    void Update()
    {
        float distance = player.position.x - transform.position.x;
        if (distance > -1.5 && distance < 1.5)
        {
            isAttacking = true;
            float ellapsedTime = Time.time - activationTime;
            if (-1 == activationTime)
            {
                activationTime = Time.time;
            }
            else if ((ellapsedTime - 0.4f) < 0.1 && (ellapsedTime - 0.4f) > 0)
            {
                fistCollider.enabled = true;
            }
            else if ((ellapsedTime - 1.4f) < 0.1 && (ellapsedTime - 1.4f) > 0)
            {
                activationTime = Time.time;
                fistCollider.enabled = false;
            }
        }
        else
        {
            fistCollider.enabled = false;
            activationTime = -1;
            isAttacking = false;
            horizontalMovement = 40 * direction;
            frames++;

            if (frames == 360)
            {
                frames = 0;
                direction *= -1;
            }
        }
        animator.SetBool("shouldAttack", isAttacking);
    }

    public static void HurtMonster()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LivesScore.instance.ChangeScore(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("isHurt");
        }
    }

    private void activateFistCollider()
    {
        fistCollider.enabled = true;
    }

    private void deactivateFistCollider()
    {
        fistCollider.enabled = false;
    }

    //Move character
    private void FixedUpdate()
    {
        if (frames > 180 && isAttacking == false)
        {
            controller.Move(horizontalMovement * Time.fixedDeltaTime, false, false);
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
