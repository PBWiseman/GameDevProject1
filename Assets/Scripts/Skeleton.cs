using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody2D rb;

    private Vector2 walkDirectionVector;

    public enum WalkableDirection { Left, Right }

    private WalkableDirection walkDirection;

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
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * walkDirectionVector, rb.velocity.y);
    }
}
