using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralingEnemyController : EnemyController
{
    
    public float circlePeriod;
    public float radiusPeriod;
    public float minRadius;
    public float maxRadius;

    private Vector3 basePosition;
    private float initialAngle;
    private float startTime;

    protected override void Awake()
    {
        base.Awake();
        this.startTime = Time.time;
        Vector3 towardsTarget = Vector3.Normalize(this.target.position - this.transform.position);
        this.basePosition = this.transform.position + minRadius*towardsTarget;
        this.initialAngle = Mathf.Atan2(towardsTarget.y, towardsTarget.x);
    }

    void Update()
    {
        float step = Time.time - this.startTime; 

        // Widening/narrowing of the circle width
        float radius = (-Mathf.Cos(step * Mathf.PI/radiusPeriod) + 1)/2 * (maxRadius - minRadius) + minRadius;

        // Movement along the circle
        float angle = (2*Mathf.PI * step/circlePeriod) + this.initialAngle;
        float yOffset = radius*Mathf.Sin(angle);
        float xOffset = radius*Mathf.Cos(angle);

        // Slight movement from following target (using speed)
        Vector3 approach = Vector3.Normalize(this.target.position - this.transform.position) * speed;
        this.basePosition = this.basePosition + approach;

        Vector3 newPosition = new Vector3(
            this.basePosition.x + xOffset,
            this.basePosition.y + yOffset,
            this.basePosition.z
        );

        Vector3 dir = newPosition - this.transform.position;
        float facingAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(facingAngle - 90, Vector3.forward);

        this.transform.position = newPosition;

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
        Vector3 oldPosition = this.transform.position;
        this.transform.position = newPosition;
        this.basePosition = this.basePosition + (this.transform.position - oldPosition);
    }
}
