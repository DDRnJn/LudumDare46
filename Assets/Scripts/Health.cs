using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        this.currentHealth = this.totalHealth;
        this.healthBar.SetMaxHealth(totalHealth);
    }

    public void takeDamage(int damage)
    {
        this.currentHealth -= damage;
        healthBar.SetHealth(this.currentHealth);
        if (this.currentHealth <= 0)
        {
            this.die();
        }
    }

    public void die()
    {
        if (this.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = this.gameObject.GetComponent<EnemyController>();
            enemyController.destroy();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
