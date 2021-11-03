using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float maximumHookDistance = 3f;
    public float hookAcceleration = 0.5f;
    public float hookThrowForce = 5f;
    public GameObject anchor;
    
    private DistanceJoint2D hook;
    private HorizontalMovement movement;
    private LineRenderer lineRenderer;
    private float baseAcceleration;
    private GameObject currentAnchor;
    
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
        if (!hook.enabled && currentAnchor != null && Vector2.Distance(currentAnchor.transform.position, transform.position) > maximumHookDistance)
        {
            currentAnchor = null;
        }
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
            LaunchAnchor();
        }
        
    }

    void LaunchAnchor()
    {
        currentAnchor = Instantiate(anchor);
        currentAnchor.transform.position = transform.position;
        currentAnchor.GetComponent<HookAnchor>().launcher = gameObject;
        currentAnchor.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * movement.direction, 1) * hookThrowForce;
    }

    void OnHookAnchored(GameObject anchoredHook)
    {
        if (anchoredHook == currentAnchor)
        {
            StartHook();
        }
        else
        {
            Destroy(anchoredHook);
        }
    }

    void StartHook()
    {
        if (currentAnchor != null)
        {
            hook.connectedBody = currentAnchor.GetComponent<Rigidbody2D>();
            movement.acceleration = hookAcceleration;
            hook.enabled = true;
            UpdateLineRenderer();
        }
    }

    void StopHook()
    {
        movement.acceleration = baseAcceleration;
        hook.enabled = false;
        Destroy(currentAnchor);
        currentAnchor = null;
    }

    void UpdateLineRenderer()
    {
        if (currentAnchor != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, currentAnchor.transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
