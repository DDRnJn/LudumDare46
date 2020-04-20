using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeekProjectile : SinProjectile
{

    public float rotationSpeed;
    float currentRotation = 1f;
    float initialAngle;

    protected override void Awake() {
        base.Awake();
        this.initialAngle = (this.transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
    }


    protected override void Update()
    {
        this.transform.Rotate(Vector3.forward, currentRotation * rotationSpeed);
        base.Update();

        float xOffset = Mathf.Cos(initialAngle) * speed;
        float yOffset = Mathf.Sin(initialAngle) * speed;
        this.transform.position = new Vector3(this.transform.position.x + xOffset,
                                            this.transform.position.y + yOffset,
                                            this.transform.position.z);
    }
}
