using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform projectilePrefab;
    // Start is called before the first frame update
    public int fireRate;
    void Start()
    {
        InvokeRepeating("fireProjectile", fireRate, fireRate);
    }

    void fireProjectile()
    {
        Transform basicProjectile = Instantiate(this.projectilePrefab, this.transform.position,
                                                this.transform.rotation);
    }

}
