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
