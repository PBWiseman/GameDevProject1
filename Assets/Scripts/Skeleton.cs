using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private float speed = 1.0f;

    private Rigidbody2D rb;

    private Vector2 walkDirectionVector;

    public enum WalkableDirection { Left, Right }

    private WalkableDirection walkDirection;

    private GameObject player;

    private Vector2 playerPosition;

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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //Get the players location and move towards it
        if (player != null)
        {
            playerPosition = player.transform.position;
            if (playerPosition.x < transform.position.x)
            {
                WalkDirection = WalkableDirection.Left;
            }
            else
            {
                WalkDirection = WalkableDirection.Right;
            }
            walkDirectionVector = playerPosition - (Vector2)transform.position;
            walkDirectionVector.y -= .7f; //This makes this skeleton move towards the player's feet rather than the center of the players model. Makes it look better
            walkDirectionVector.Normalize();
            rb.velocity = new Vector2(speed * walkDirectionVector.x, speed * walkDirectionVector.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
