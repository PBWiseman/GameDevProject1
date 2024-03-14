using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GolemMovement : MonoBehaviour
{
    private float movementSpeed = 3f;
    GolemAnimation golemAnimation;

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
            Debug.Log("IsMoving: " + value);
            animator.SetBool("IsMoving", value);
        }
    }
    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        golemAnimation = GetComponent<GolemAnimation>();
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Debug.Log(movement.magnitude);
        if (movement.magnitude < .01f)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
        //golemAnimation.Movement(movement);
        rb.MovePosition(newPos);
    }

    // public void OnMove(InputValue value)
    // {
    //     Vector2 currentPos = rb.position;
    //     Vector2 inputVector = value.Get<Vector2>();
    //     Vector2 movement = inputVector * movementSpeed;
    //     Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
    //     if(inputVector.x < 0)
    //     {
    //         transform.localScale = new Vector3(-1, 1, 1);
    //     }
    //     else if(inputVector.x > 0)
    //     {
    //         transform.localScale = new Vector3(1, 1, 1);
    //     }
    //     golemAnimation.Movement(inputVector);
    //     rb.MovePosition(newPos);
    // }

    // public void OnAttack1()
    // {
    //     golemAnimation.Attack1();
    // }

    // public void OnAttack2()
    // {
    //     golemAnimation.Attack2();
    // }
}
