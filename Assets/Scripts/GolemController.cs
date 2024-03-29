using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GolemController : MonoBehaviour
{
    private float movementSpeed = 3f;

    public float CurrentSpeed
    {
        get
        {
            if (!CanMove)
            {
                //Not allowed to move
                return 0;
            }
            if (IsMoving)
            {
                //Moving Speed
                return movementSpeed;
            }
            else
            {
                //Idle Speed
                return 0;
            }
        }
    }
    private Vector2 moveInput;
    private bool _ismoving = false;
    public bool IsMoving
    {
        get
        {
            return _ismoving;
        }
        private set
        {
            _ismoving = value;
            animator.SetBool(AnimationStrings.IsMoving, value);
        }
    }
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool isAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentSpeed, moveInput.y * CurrentSpeed);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if(isAlive) //If the player is not alive they cannot move
        {
            IsMoving = false;
            return;
        }
        //If the move input is not zero then the golem is moving and the animation will play
        IsMoving = moveInput != Vector2.zero;
        //This will flip the sprite if it moves the opposite direction but if it doesnt move at all it will stay facing the same way
        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void OnAttack1()
    {
        animator.SetTrigger(AnimationStrings.attack1);
    }

    public void OnAttack2()
    {
        animator.SetTrigger(AnimationStrings.attack2);
    }
}
