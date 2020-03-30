using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float TopValue;
    private Vector2 movementFactor;
    private Rigidbody2D rigidBody;
    private bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = new Vector2(0, 1);
    }

    private void FixedUpdate()
    {
        if (shouldMove && rigidBody.position.y<TopValue)
        {
            rigidBody.MovePosition(rigidBody.position + movementFactor * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }
}
