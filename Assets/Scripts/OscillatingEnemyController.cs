using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingEnemyController : EnemyController
{
    public List<Vector3> directions;

    public Vector3 currentDirection;

    void Start()
    {
        this.currentDirection = this.directions[Random.Range(0, this.directions.Count)];
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        this.transform.position += this.currentDirection * step;
    }

    void changeCurrentDirection()
    {
        if (this.directions.Count > 1)
        {
            Vector3 newDirection = this.directions[Random.Range(0, this.directions.Count)];
            if (newDirection == currentDirection)
            {
                this.changeCurrentDirection();
            }
            else
            {
                this.currentDirection = newDirection;
            }
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
                health.takeDamage(2);
            }
            this.changeCurrentDirection();
        }

    }
}
