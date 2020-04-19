using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRestrictedEnemyController : EnemyController
{

    public float minDistance;
    public float towardsSpeedScale;
    public float awaySpeedScale;

    void Update()
    {
        if (Vector3.Distance(this.transform.position, this.target.position) > minDistance) {
            float step = towardsSpeedScale * speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position,
                                                      this.target.position,
                                                      step);
        } else {
            float step = awaySpeedScale * speed * Time.deltaTime;
            this.transform.position = this.transform.position + step * Vector3.Normalize(this.transform.position - this.target.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        Health health = other.GetComponent<Health>();
        if (health)
        {
            health.takeDamage(1);
        }
        this.bounceBack();
    }

    void bounceBack()
    {
        Vector2 newPosition = Vector2.MoveTowards(this.transform.position,
                                                      this.target.position,
                                                      -0.6f);
        this.transform.position = newPosition;
    }
}
