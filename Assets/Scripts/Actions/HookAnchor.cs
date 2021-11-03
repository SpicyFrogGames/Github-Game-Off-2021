using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAnchor : MonoBehaviour
{
    public GameObject launcher;

    private Rigidbody2D body2D;
    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("OnHookHit", gameObject, SendMessageOptions.DontRequireReceiver);
        if (other.gameObject.layer == LayerMask.NameToLayer("Solid"))
        {
            body2D.bodyType = RigidbodyType2D.Static;
            launcher.SendMessage("OnHookAnchored", gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }
}
