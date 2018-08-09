using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc2_Enemy : MonoBehaviour {
    public float health = 1f;
    
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

	
}
