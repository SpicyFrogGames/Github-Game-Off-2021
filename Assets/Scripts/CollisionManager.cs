using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public ContactFilter2D down;
    public ContactFilter2D left;
    public ContactFilter2D up;
    public ContactFilter2D right;

    private bool wasTouchingDown = false;
    private bool wasTouchingLeft = false;
    private bool wasTouchingRight = false;
    private bool wasTouchingUp = false;

    private Rigidbody2D body2D;

    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ManageCollisionChange(ref wasTouchingDown, IsTouchingDown(), "Down");
        ManageCollisionChange(ref wasTouchingLeft, IsTouchingLeft(), "Left");
        ManageCollisionChange(ref wasTouchingRight, IsTouchingRight(), "Right");
        ManageCollisionChange(ref wasTouchingUp, IsTouchingUp(), "Up");
    }

    private void ManageCollisionChange(ref bool oldValue, bool newValue, string direction)
    {
        if (oldValue && !newValue)
        {
            BroadcastMessage("OnLeaving" + direction, SendMessageOptions.DontRequireReceiver);
        }

        if (!oldValue && newValue)
        {
            BroadcastMessage("OnTouching" + direction, SendMessageOptions.DontRequireReceiver);
        }

        oldValue = newValue;
    }

    public bool IsTouchingDown()
    {
        return body2D.IsTouching(down);
    }

    public bool IsTouchingLeft()
    {
        return body2D.IsTouching(left);
    }

    public bool IsTouchingRight()
    {
        return body2D.IsTouching(right);
    }

    public bool IsTouchingUp()
    {
        return body2D.IsTouching(up);
    }
}
