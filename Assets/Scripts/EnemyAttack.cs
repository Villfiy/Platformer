using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 25f;
    public float attackCooldown = 1f; // Adjust the cooldown time as needed

    private bool _canAttack = true;
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")||!_canAttack)
            return;
        other.gameObject.TryGetComponent(out Character playerControl);
        
            AttackPlayer(playerControl);

            // Set the cooldown timer
            StartCoroutine(AttackCooldown());
    }
    
    

    private void AttackPlayer(Character target)
    {
        target.ReceiveDamage(damage);
    }
    private IEnumerator AttackCooldown()
    {
        // Set canAttack to false to prevent further attacks
        _canAttack = false;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Set canAttack to true to enable attacks again
        _canAttack = true;
    }
    
}
