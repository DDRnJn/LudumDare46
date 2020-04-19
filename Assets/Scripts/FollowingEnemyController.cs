using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemyController : EnemyController
{
    void Update()
    {
        float step = speed * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(this.transform.position,
                                                      this.target.position,
                                                      step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        Health health = other.GetComponent<Health>();
        if (health)
        {
            health.takeDamage(1);
        }
    }
}
