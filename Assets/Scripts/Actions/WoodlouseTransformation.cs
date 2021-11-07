using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WoodlouseTransformation : MonoBehaviour
{
    public float ballSpeed;
    public float ballAcceleration;
    public Collider2D normalCollider;
    public Collider2D ballCollider;
    public bool isBall { get; private set; } = false;

    private HorizontalMovement movement;
    private Jump jump;
    private float normalSpeed;
    private float normalAcceleration;
    
    void Start()
    {
        jump = GetComponent<Jump>();
        movement = GetComponentInParent<HorizontalMovement>();
        normalSpeed = movement.maximumSpeed;
        normalAcceleration = movement.acceleration;
    }

    void OnAction(InputValue value)
    {
        if (value.Get<float>() == 1f)
        {
            if (isBall)
            {
                // Transforms to normal
                isBall = false;
                movement.maximumSpeed = normalSpeed;
                movement.acceleration = normalAcceleration;
                normalCollider.enabled = true;
                ballCollider.enabled = false;
                jump.enabled = true;
                BroadcastMessage("OnUnroll", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                // Transforms to ball
                isBall = true;
                movement.maximumSpeed = ballSpeed;
                movement.acceleration = ballAcceleration;
                normalCollider.enabled = false;
                ballCollider.enabled = true;
                jump.enabled = false;
                BroadcastMessage("OnRoll", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
