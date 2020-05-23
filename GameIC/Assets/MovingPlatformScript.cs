using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float GoToValue;
    public Direction direction = Direction.Uppwards;
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
        if (direction == Direction.Uppwards)
        {
            movementFactor = new Vector2(0, 3);
        }
        else if (direction == Direction.Downwards)
        {
            movementFactor = new Vector2(0, -3);
        }
    }

    private void FixedUpdate()
    {
        if ((direction == Direction.Uppwards && shouldMove && rigidBody.position.y < GoToValue) ||
            (direction == Direction.Downwards && shouldMove && rigidBody.position.y > GoToValue))
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

    public enum Direction
    {
        Uppwards,
        Downwards
    }
}
