using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinProjectile : Projectile
{
    Vector3 projectileStart;

    public float frequency;

    public float magnitude;

    protected override void Awake()
    {
        base.Awake();
        this.projectileStart = transform.position;
    }

    protected override void Update()
    {
        float angle = (this.transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
        float xOffset = Mathf.Cos(angle) * speed;
        float yOffset = Mathf.Sin(angle) * speed;

        this.transform.position = new Vector3(this.transform.position.x + xOffset,
                                            this.transform.position.y + yOffset,
                                            this.transform.position.z);
    }

}
