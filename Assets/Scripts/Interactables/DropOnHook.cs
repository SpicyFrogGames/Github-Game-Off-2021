using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropOnHook : MonoBehaviour
{
    public float timeBeforeFall = 1f;
    public float rumbleSpeed = 10f;
    public float maximumRumbleRotation = 5f;
    
    private bool falling;
    private Rigidbody2D body2D;
    private float startRumbleTime;
    private int currentRumbleDirection = 1;
    private float startZAngle;
    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void OnHookAnchored()
    {
        if (!falling)
        {
            falling = true;
            RumbleAndFall();
        }
    }

    void RumbleAndFall()
    {
        StartCoroutine(Rumble());
    }

    IEnumerator Rumble()
    {
        startRumbleTime = Time.time;
        startZAngle = transform.rotation.eulerAngles.z;
        while (Time.time - startRumbleTime < timeBeforeFall)
        {
            if (transform.rotation.eulerAngles.z >= startZAngle + maximumRumbleRotation ||
                transform.rotation.eulerAngles.z <= startZAngle - maximumRumbleRotation)
            {
                currentRumbleDirection *= -1;
            }
            transform.Rotate(0, 0, rumbleSpeed * currentRumbleDirection * Time.deltaTime);
            
            yield return new WaitForFixedUpdate();
        }
        //transform.localRotation = Quaternion.Euler(0, 0, startZAngle);
        body2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
