using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WoodlouseTransformation : MonoBehaviour
{
    public GameObject normalForm;
    public GameObject ballForm;
    public float normalSpeed;
    public float normalAcceleration;
    public float ballSpeed;
    public float ballAcceleration;

    private HorizontalMovement movement;
    private bool isBall = false;
    
    void Start()
    {
        movement = GetComponent<HorizontalMovement>();
    }

    void OnAction(InputValue value)
    {
        if (value.Get<float>() == 1f)
        {
            if (isBall)
            {
                normalForm.SetActive(true);
                ballForm.SetActive(false);
                isBall = false;
                movement.maximumSpeed = normalSpeed;
                movement.acceleration = normalAcceleration;
            }
            else
            {
                normalForm.SetActive(false);
                ballForm.SetActive(true);
                isBall = true;
                movement.maximumSpeed = ballSpeed;
                movement.acceleration = ballAcceleration;
            }
        }
    }
}
