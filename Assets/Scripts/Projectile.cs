using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifetime;

    public string targetTag;

    public string selfTag;

    public bool canDamageWalls = true;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        Destroy(this.gameObject, this.lifetime);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float angle = (this.transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
        float xOffset = Mathf.Cos(angle) * speed;
        float yOffset = Mathf.Sin(angle) * speed;
        this.transform.position = new Vector3(this.transform.position.x + xOffset,
                                            this.transform.position.y + yOffset,
                                            this.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == this.selfTag || other.tag == "GatePickup" || (this.selfTag == "Player" && other.tag == "GatePlayer"))
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
        else
        {
            Health health = other.GetComponent<Health>();
            if (health && other.tag == targetTag)
            {
                health.takeDamage(1);
            }
            if (health && other.tag == "Wall" && canDamageWalls)
            {
                health.takeDamage(1);
            }
            Destroy(this.gameObject);
        }
    }
}
