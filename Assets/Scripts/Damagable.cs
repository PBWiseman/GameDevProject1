/// <remarks>
/// Author: Palin Wiseman
/// Date Created: March 24, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to handle the health of an object
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    Animator animator;
    //Invincibility time after being hit
    public float invincibilityTime = 0.25f;
    //Time since last hit
    private float timeSinceHit = 0;
    //Max health of the object
    [SerializeField] private int maxHealth = 100;
    //Public accessor for max health
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        
        }
    }
    //Current health of the object
    [SerializeField] private int health = 100;
    //Public accessor for health
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            //if dead
            if (health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    //Boolean for if the object is alive
    private bool isAlive = true;
    //Public accessor for isAlive
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
        }
    }
    //Boolean for if the object is invincible
    private bool isInvincible = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //If invincible, check if invincibility time has passed
        if (isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            else
            {
                timeSinceHit += Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Deal damage to the object
    /// </summary>
    /// <param name="damage">Damage to be dealt</param>
    public void Hit(int damage)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            Debug.Log("Health: " + Health);
            animator.SetTrigger(AnimationStrings.isHit);
        }
    }
}
