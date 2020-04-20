using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemyController : EnemyController
{
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 dir = this.target.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        this.transform.position = Vector2.MoveTowards(this.transform.position,
                                                      this.target.position,
                                                      step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == this.tag)
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
        else
        {
            Health health = other.GetComponent<Health>();
            if (health)
            {
                health.takeDamage(1);
            }
            this.bounceBack();
        }
    }

    void bounceBack()
    {
        Vector2 newPosition = Vector2.MoveTowards(this.transform.position,
                                                      this.target.position,
                                                      -0.6f);
        this.transform.position = newPosition;
    }
}
