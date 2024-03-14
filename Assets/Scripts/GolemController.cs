using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GolemController : MonoBehaviour
{
    private float movementSpeed = 3f;
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
            animator.SetBool("IsMoving", value);
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
        rb.velocity = new Vector2(moveInput.x * movementSpeed, moveInput.y * movementSpeed);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //If the move input is not zero then the golem is moving and the animation will play
        IsMoving = moveInput != Vector2.zero;
        //This will flip the sprite if it moves the opposite direction but if it doesnt move at all it will stay facing the same way
        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // public void OnAttack1()
    // {
    //
    // }

    // public void OnAttack2()
    // {
    //
    // }
}
