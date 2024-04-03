using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Skeleton : MonoBehaviour
{
    private float movementSpeed = 1.0f;

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

    public bool isAttacking
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAttacking);
        }
    }

    private Rigidbody2D rb;

    private Vector2 walkDirectionVector;

    public enum WalkableDirection { Left, Right }

    private WalkableDirection walkDirection;

    private GameObject player;

    private Vector2 playerPosition;
    private Animator animator;

    public WalkableDirection WalkDirection
    {
        get { return walkDirection; }
        set
        {
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
                return;
            }
            playerPosition = player.transform.position;
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
            IsMoving = false;
            rb.velocity = new Vector2(0, 0);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void OnAttack()
    {
        animator.SetTrigger(AnimationStrings.attack);
    }

}
