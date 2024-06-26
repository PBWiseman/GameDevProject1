/// <remarks>
/// Author: Palin Wiseman
/// Date Created: April 4, 2024
/// Bugs: None known at this time.
/// </remarks>
// <summary>
/// This script is used to handle attacking
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider2D hitbox;

    public int attackDamage = 10;
    
    private void Awake()
    {
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = false;
    }

    /// <summary>
    /// Deal damage to the object that is hit
    /// </summary>
    /// <param name="collision">Collider entered</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(attackDamage);
            Debug.Log("Hit " + collision.name);
        }
    }
}
