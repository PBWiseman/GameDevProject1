using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimation : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Movement(Vector2 direction)
    {
        if (direction.magnitude < .01f)
        {
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Move");
        }
    }
}
