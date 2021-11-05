using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 1;
    public LayerMask hittable;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // It's strange, but it seems to be how you chek if a layer is in a LayerMask
        if (((1 << other.gameObject.layer) & hittable) != 0)
        {
            other.gameObject.BroadcastMessage("OnHit", this, SendMessageOptions.DontRequireReceiver);
        }
    }
}
