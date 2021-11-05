using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookAnchor : MonoBehaviour
{
    public GameObject launcher;

    private FixedJoint2D joint;
    private void Start()
    {
        joint = GetComponent<FixedJoint2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D targetBody = other.gameObject.GetComponent<Rigidbody2D>();
        if (targetBody != null)
        {
            joint.connectedBody = targetBody;
            joint.enabled = true;
            AnchorData data = new AnchorData(gameObject, other.gameObject);
            other.gameObject.SendMessage("OnHookHit", data, SendMessageOptions.DontRequireReceiver);
            launcher.SendMessage("OnHookHit", data, SendMessageOptions.DontRequireReceiver);
        }
    }
}
