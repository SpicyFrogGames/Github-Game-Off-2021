using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavierOnHook : MonoBehaviour
{
    private Rigidbody2D body2D;

    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void OnHookHit(GameObject hook)
    {
        body2D.gravityScale = 2f;
        Destroy(hook);
    }
}
