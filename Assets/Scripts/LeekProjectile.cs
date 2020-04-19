using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeekProjectile : SinProjectile
{

    float currentRotation = 1f;

    protected override void Update()
    {
        this.transform.Rotate(Vector3.forward, currentRotation);
        base.Update();
    }
}
