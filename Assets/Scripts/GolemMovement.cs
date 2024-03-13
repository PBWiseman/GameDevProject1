using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GolemMovement : MonoBehaviour
{
    private float movementSpeed = 3f;
    GolemAnimation golemAnimation;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        golemAnimation = GetComponent<GolemAnimation>();
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
        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        golemAnimation.Movement(movement);
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

    public void OnAttack1()
    {
        golemAnimation.Attack1();
    }

    public void OnAttack2()
    {
        golemAnimation.Attack2();
    }
}
