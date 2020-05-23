using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float GoToUppwardsValue;
    public float GoToDownwardsValue;
    public Direction direction = Direction.Uppwards;
    public Direction originalDirection;
    private Vector2 movementFactor;
    private Rigidbody2D rigidBody;
    private bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        originalDirection = direction;
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
        if ((direction == Direction.Uppwards && shouldMove && rigidBody.position.y < GoToUppwardsValue) ||
            (direction == Direction.Downwards && shouldMove && rigidBody.position.y > GoToDownwardsValue))
        {
            rigidBody.MovePosition(rigidBody.position + movementFactor * Time.fixedDeltaTime);
        }
        else if (direction == Direction.Uppwards && shouldMove && rigidBody.position.y >= GoToUppwardsValue)
        {
            shouldMove = false;
            direction = Direction.Downwards;
            Invoke("MoveBack", 5f);
        }
        else if (direction == Direction.Downwards && shouldMove && rigidBody.position.y <= GoToDownwardsValue)
        {
            shouldMove = false;
            direction = Direction.Uppwards;
            Invoke("MoveBack", 5f);
        }
    }

    private void MoveBack()
    {
        if (shouldMove == false && direction != originalDirection)
        {
            shouldMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && direction == originalDirection)
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
