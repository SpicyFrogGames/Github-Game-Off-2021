using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnHook : MonoBehaviour
{
    private Rigidbody2D body2D;
    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void OnHookAnchored()
    {
        body2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
