using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifetime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, this.lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x * this.speed,
                                            this.transform.position.y * this.speed,
                                            this.transform.position.z);
    }
}
