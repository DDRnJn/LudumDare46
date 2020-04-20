using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemyController : EnemyController
{

    public float period;
    public float bounceHeight;
    public float bounceWidth;
    public int bounceRange;

    private float startTime;
    private Vector3 basePosition;

    protected override void Awake()
    {
        base.Awake();
        this.startTime = Time.time;
        this.basePosition = this.transform.position;
    }

    void Update()
    {

        // Bounce calculations (uses period rather than speed)
        float step = Time.time - this.startTime;
        float y = bounceHeight * Mathf.Abs(Mathf.Sin(step * Mathf.PI / period));
        float x = xOffset(step);

        // Slight movement from following target (using speed)
        Vector3 approach = Vector3.Normalize(this.target.position - this.transform.position) * speed;
        this.basePosition = this.basePosition + approach;

        this.transform.position = new Vector3(
            this.basePosition.x + x,
            this.basePosition.y + y,
            this.basePosition.z
        );
    }

    private float xOffset(float step)
    {
        int bounceIndex = Mathf.FloorToInt(step / period) % (2 * bounceRange);
        float normalStep = step % (bounceRange * period);
        if (bounceIndex < bounceRange)
        {
            return normalStep * bounceWidth / period;
        }
        else
        {
            float maxDist = bounceRange * bounceWidth;
            return maxDist - (normalStep * bounceWidth / period);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == this.tag || other.tag == "GatePickup")
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
            this.bounceBack(other);
        }
    }

    void bounceBack(GameObject other)
    {
        Vector2 newPosition = Vector2.MoveTowards(this.transform.position,
                                                      other.transform.position,
                                                      -0.6f);
        Vector3 oldPosition = this.transform.position;
        this.transform.position = newPosition;
        this.basePosition = this.basePosition + (this.transform.position - oldPosition);
    }
}
