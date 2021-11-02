using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wallclimb : MonoBehaviour
{
    public float maximumSpeed = 7f;
    public float acceleration = 1f;

    private Rigidbody2D body2D;
    private float direction = 0f;
    private int contacts = 0;
    private float gravityScale;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        gravityScale = body2D.gravityScale;
    }

    private void FixedUpdate()
    {
        body2D.velocity = new Vector2(body2D.velocity.x, Mathf.MoveTowards(body2D.velocity.y, maximumSpeed * direction, acceleration * Time.fixedDeltaTime));
    }

    private void OnVerticalMovement(InputValue value)
    {
        direction = value.Get<float>();
    }

    void StartClimb()
    {
        contacts++;
        body2D.gravityScale = 0f;
    }

    void StopClimb()
    {
        contacts--;
        if (contacts == 0)
        {
            body2D.gravityScale = gravityScale;
        }
    }
    
    private void OnTouchingLeft()
    {
        StartClimb();
    }
    
    private void OnTouchingRight()
    {
        StartClimb();
    }
    
    private void OnTouchingUp()
    {
        StartClimb();
    }
    
    private void OnLeavingLeft()
    {
        StopClimb();
    }
    
    private void OnLeavingRight()
    {
        StopClimb();
    }
    
    private void OnLeavingUp()
    {
        StopClimb();
    }
}
