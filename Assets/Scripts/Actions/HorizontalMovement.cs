using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMovement : MonoBehaviour
{
    public float maximumSpeed = 7f;
    public float acceleration = 1f;

    private Rigidbody2D body2D;
    private float direction = 0f;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body2D.velocity = new Vector2(Mathf.MoveTowards(body2D.velocity.x, maximumSpeed * direction, acceleration * Time.fixedDeltaTime), body2D.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<float>();
    }
}
