using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected bool _isGrounded = true;
    protected bool _canDoubleJump = true;
    
    

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Floor"))
            return;
        _isGrounded = true;
        _canDoubleJump = true;
    }
    
  
}
