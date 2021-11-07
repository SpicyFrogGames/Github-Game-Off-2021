using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBasedHitbox : MonoBehaviour
{
    public float minimumHitboxSpeed;
    public Collider2D hitbox;
    
    private Rigidbody2D body2D;
    
    void Start()
    {
        body2D = transform.root.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hitbox.enabled = body2D.velocity.magnitude >= minimumHitboxSpeed;
    }
}
