using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public bool canTakeDamage = true;

    private void Awake()
    {
        this.currentHealth = this.totalHealth;
        if (healthBar)
        {
            this.healthBar.SetMaxHealth(totalHealth);
        }
    }

    public void takeDamage(int damage)
    {
        if (canTakeDamage)
        {
            this.currentHealth -= damage;
            if (healthBar)
            {
                healthBar.SetHealth(this.currentHealth);
            }
            if (this.currentHealth <= 0)
            {
                this.die();
            }
        }
    }

    public void die()
    {
        if (this.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = this.gameObject.GetComponent<EnemyController>();
            enemyController.destroy();
        }
        else if (this.gameObject.tag == "Player")
        {
            LevelInitManager levelInitManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelInitManager>();
            levelInitManager.endLevelDefeat();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
