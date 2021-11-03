using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float maxReleaseForce;
    public float jumpForce;

    private Rigidbody2D body2D;
    private bool canJump = false;

    void Start()
    {
        body2D = GetComponentInParent<Rigidbody2D>();
    }

    void OnJump(InputValue value)
    {
        if (value.Get<float>() == 1f)
        {
            DoJump();
        }
        else
        {
            StopJump();
        }
    }

    private void DoJump()
    {
        if (canJump)
        {
            body2D.velocity = new Vector2(body2D.velocity.x, jumpForce);
        }
    }

    public void StopJump()
    {
        if (body2D.velocity.y > maxReleaseForce)
        {
            body2D.velocity = new Vector2(body2D.velocity.x, maxReleaseForce);
        }
    }

    private void OnTouchingDown()
    {
        canJump = true;
    }

    private void OnLeavingDown()
    {
        canJump = false;
    }
}
