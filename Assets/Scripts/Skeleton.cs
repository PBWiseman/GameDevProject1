/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 21, 2024
/// Bugs: Skeleton can be moved on death
///       Skeleton body doesn't disappear immediately
/// </remarks>
// <summary>
/// This script is used to handle the skeleton enemy
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Skeleton : MonoBehaviour
{
    //Speed of the skeleton
    private float movementSpeed = 1.0f;
    //Current speed of the skeleton
    public float CurrentSpeed
    {
        get
        {
            if (!CanMove || !isAlive)
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
    //Boolean for if the skeleton is moving
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
    //Boolean for if the skeleton can move
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    //Boolean for if the skeleton is alive
    public bool isAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
    //Boolean for if the skeleton is attacking
    public bool isAttacking
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAttacking);
        }
    }

    private Rigidbody2D rb;

    private Vector2 walkDirectionVector;
    //Enum for the direction the skeleton can walk
    public enum WalkableDirection { Left, Right }

    private GameObject player;
    //Current position of the player
    private Vector2 playerPosition;
    private Animator animator;
    //The direction the skeleton is walking
    private WalkableDirection walkDirection;
    //Public accessor for walk direction
    public WalkableDirection WalkDirection
    {
        get { return walkDirection; }
        set
        {
            //If the direction is different then flip the sprite
            if(value != walkDirection)
            {
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                if(value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else
                {
                    walkDirectionVector = Vector2.left;
                }
            }
            walkDirection = value;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //Find the player object
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //Get the players location and move towards it
        if (player != null)
        {
            if(!isAlive) //If the enemy is not alive they cannot move
            {
                IsMoving = false;
                rb.velocity = new Vector2(0, 0);
                return;
            }
            playerPosition = player.transform.position;
            //If the player is to the left of the skeleton, walk left. Otherwise walk right
            if (!isAttacking)
            {
                if (playerPosition.x < transform.position.x)
                {
                    WalkDirection = WalkableDirection.Left;
                }
                else
                {
                    WalkDirection = WalkableDirection.Right;
                }
            }
            //If player is near the x axis and roughly the same y axis then attack
            if (Mathf.Abs(playerPosition.x - transform.position.x) < 1.8f && Mathf.Abs((playerPosition.y) - transform.position.y) < .8f)
            {
                OnAttack();
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
            }
            walkDirectionVector = playerPosition - (Vector2)transform.position;
            walkDirectionVector.y -= .7f; //This makes this skeleton move towards the player's feet rather than the center of the players model. Makes it look better
            walkDirectionVector.Normalize();
            rb.velocity = new Vector2(CurrentSpeed * walkDirectionVector.x, CurrentSpeed * walkDirectionVector.y);
        }
        else
        {
            //If the player is null then the player is dead and the skeleton should stop moving
            IsMoving = false;
            rb.velocity = new Vector2(0, 0);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    /// <summary>
    /// This function is called when the skeleton attacks
    /// </summary> 
    public void OnAttack()
    {
        animator.SetTrigger(AnimationStrings.attack);
    }

}
