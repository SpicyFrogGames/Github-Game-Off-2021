using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float maximumHookDistance = 3f;
    public float hookAcceleration = 0.5f;
    
    private DistanceJoint2D hook;
    private HorizontalMovement movement;
    private LineRenderer lineRenderer;
    private float baseAcceleration;
    
    // Start is called before the first frame update
    void Start()
    {
        hook = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
        movement = GetComponent<HorizontalMovement>();
        baseAcceleration = movement.acceleration;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateLineRenderer();
    }

    void OnAction()
    {
        if (hook.enabled)
        {
            StopHook();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position, 
                new Vector2(1 * movement.direction, 1),
                maximumHookDistance,
                LayerMask.GetMask("Solid")
            );
        
            if (hit)
            {
                StartHook(hit.point);
            }
        }
        
    }

    void StartHook(Vector2 hookPoint)
    {
        hook.connectedBody.transform.position = hookPoint;
        movement.acceleration = hookAcceleration;
        hook.enabled = true;
        lineRenderer.enabled = true;
        UpdateLineRenderer();
    }

    void StopHook()
    {
        movement.acceleration = baseAcceleration;
        hook.enabled = false;
        lineRenderer.enabled = false;
    }

    void UpdateLineRenderer()
    {
        lineRenderer.SetPosition(0, hook.connectedBody.transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
