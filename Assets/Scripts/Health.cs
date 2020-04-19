using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;

    private void Awake()
    {
        this.currentHealth = this.totalHealth;
    }

    public void takeDamage(int damage)
    {
        this.currentHealth -= damage;
        if (this.currentHealth <= 0)
        {
            this.die();
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
