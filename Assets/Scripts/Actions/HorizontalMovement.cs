using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMovement : MonoBehaviour
{
    public float maximumSpeed = 7f;
    public float acceleration = 1f;
    public bool canMove = true;
    public float direction { get; private set; } = 0f;

    private Rigidbody2D body2D;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            body2D.velocity =
                new Vector2(
                    Mathf.MoveTowards(body2D.velocity.x, maximumSpeed * direction, acceleration * Time.fixedDeltaTime),
                    body2D.velocity.y
                    );
        }
    }

    private void OnHorizontalMovement(InputValue value)
    {
        direction = value.Get<float>();
    }
}
