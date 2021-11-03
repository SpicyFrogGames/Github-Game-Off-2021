using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WoodlouseTransformation : MonoBehaviour
{
    public GameObject normalForm;
    public GameObject ballForm;
    public float ballSpeed;
    public float ballAcceleration;

    private HorizontalMovement movement;
    private Jump jump;
    private bool isBall = false;
    private float normalSpeed;
    private float normalAcceleration;
    
    void Start()
    {
        jump = GetComponent<Jump>();
        movement = GetComponent<HorizontalMovement>();
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
                normalForm.SetActive(true);
                ballForm.SetActive(false);
                isBall = false;
                movement.maximumSpeed = normalSpeed;
                movement.acceleration = normalAcceleration;
                jump.enabled = true;
            }
            else
            {
                // Transforms to ball
                normalForm.SetActive(false);
                ballForm.SetActive(true);
                isBall = true;
                movement.maximumSpeed = ballSpeed;
                movement.acceleration = ballAcceleration;
                jump.enabled = false;
            }
        }
    }
}
