/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 15, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to control the golem player character
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GolemController : MonoBehaviour
{
    //Base movement speed
    private float movementSpeed = 3f;

    //Current speed of the golem
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
    //Boolean for if the golem is moving
    private bool _ismoving = false;
    //Public accessor for isMoving
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
    //Boolean for if the golem can move
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    //Boolean for if the golem is alive
    public bool isAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentSpeed, moveInput.y * CurrentSpeed);
        if(!isAlive) //If the player is not alive they cannot move
        {
            GameOver();
            return;
        }
    }
    /// <summary>
    /// This function is called when the player moves
    /// </summary>
    /// <param name="value">Move input</param>
    public void OnMove(InputValue value)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
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

    /// <summary>
    /// This function is called when the player dies
    /// </summary>
    public void GameOver()
    {
        //Stop game timer
        Time.timeScale = 0;
    }
    
    /// <summary>
    /// This function is called when the player uses attack 1
    /// </summary>
    public void OnAttack1()
    {
        animator.SetTrigger(AnimationStrings.attack1);
    }

    /// <summary>
    /// This function is called when the player uses attack 2	
    /// </summary>
    public void OnAttack2()
    {
        animator.SetTrigger(AnimationStrings.attack2);
    }
}
