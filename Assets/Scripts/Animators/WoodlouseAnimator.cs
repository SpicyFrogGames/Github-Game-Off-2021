using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class WoodlouseAnimator : MonoBehaviour
{
    public GameObject spriteContainer;
    
    private AnimatorManager animator;
    private Rigidbody2D body2D;
    private WoodlouseTransformation transformation;
    private float direction = 1f;
    private bool rolling; 

    void Start()
    {
        animator = GetComponent<AnimatorManager>();
        body2D = transform.root.GetComponent<Rigidbody2D>();
        transformation = transform.root.GetComponentInChildren<WoodlouseTransformation>();
    }

    private void Update()
    {
        if (transformation.isBall)
        {
            Roll();
            spriteContainer.transform.Rotate(0, 0, body2D.velocity.x * -50f * Time.deltaTime);
        }
        else
        {
            spriteContainer.transform.localScale = new Vector3(direction, 1, 1);
            spriteContainer.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!rolling)
            {
                if (Mathf.Abs(body2D.velocity.x) > 0.01f)
                {
                    Walk();
                }
                else
                {
                    Idle();
                }
            }
        }
        
    }

    public void Idle()
    {
        animator.ChangeAnimationState("claude_idle");
    }

    public void Walk()
    {
        animator.ChangeAnimationState("claude_walk");
    }

    public void Roll()
    {
        animator.ChangeAnimationState("claude_roll");
    }

    public void Unroll()
    {
        animator.ChangeAnimationState("claude_unroll");
    }

    public void OnUnrollFinished()
    {
        rolling = false;
    }

    void OnGoingLeft()
    {
        direction = -1f;
    }

    void OnGoingRight()
    {
        direction = 1f;
    }

    void OnUnroll()
    {
        rolling = true;
        Unroll();
    }
}
