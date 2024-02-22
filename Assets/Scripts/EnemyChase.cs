using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : BaseMovement
{
    public Transform player; // Reference to the player's transform
    private bool _isplayerNotNull;
    public float jumpThreshold = 1.5f; // Threshold for determining when to jump
    private Rigidbody2D _rb;
    public float moveSpeed = 5f; // Speed at which the enemy moves
    public float jumpForce = 10f; // Force applied when the enemy jumps

    private void Start()
    {
        _isplayerNotNull = player != null;
        _rb= gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (_isplayerNotNull)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;

            if (Mathf.Abs(direction.y) > jumpThreshold)
            {
                // Jump
                Jump();
                print("Enemy Jumped");
            }
            // Normalize the direction vector to maintain a consistent speed
            direction.Normalize();

            // Move the enemy towards the player using Rigidbody2D
            _rb.velocity = new Vector2(direction.x * moveSpeed, _rb.velocity.y);

            // Check if the enemy can't reach the player on the Y-axis
            
            
        }
    }
    
    private void Jump()
    {
        // Check if the enemy is grounded (you should have a grounded check implementation)
        // For simplicity, let's assume you have a method IsGrounded() that returns a boolean indicating if the enemy is on the ground.
        if (_isGrounded)
        {
            // Apply jump force
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * jumpForce); //Добавление силы прыжка
            _isGrounded = false;
            _canDoubleJump = true;
            //Debug.Log("Jumped");  
            
            
        }
    }


    

    
    
}
